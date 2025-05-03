using BitePaper.Models.DTOs.Request.Document;
using BitePaper.Models.Entities;
using FastEndpoints;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using BitePaper.Infrastructure.Interfaces.Documents;

namespace BitePaper.Api.Controllers.Documents.Upload;

public class UploadDocumentEndpoint : Endpoint<UploadDocumentRequest>
{
    private readonly IConfiguration _configuration;
    private readonly IDocumentService _documentRepository;

    public UploadDocumentEndpoint(IConfiguration configuration, IDocumentService documentRepository)
    {
        _configuration = configuration;
        _documentRepository = documentRepository;
    }

    public override void Configure()
    {
        Post("document/upload");
        AllowFileUploads();
        // TODO: Додайте відповідну авторизацію замість AllowAnonymous()
        AllowAnonymous();
    }

    public override async Task HandleAsync(UploadDocumentRequest req, CancellationToken ct)
    {
        if (req.File == null || req.File.Length == 0)
        {
            AddError("File is required and cannot be empty");
            await SendErrorsAsync(cancellation: ct);
            return;
        }

        if (string.IsNullOrWhiteSpace(req.UserEmail))
        {
            AddError("Email is required to grant access to the uploaded file");
            await SendErrorsAsync(cancellation: ct);
            return;
        }

        try
        {
            // Авторизація до Google Drive
            var credentialsPath = _configuration["GoogleDrive:CredentialsPath"] ?? "credentials.json";
            if (!File.Exists(credentialsPath))
            {
                AddError($"Google Drive credentials file not found at path: {credentialsPath}");
                await SendErrorsAsync(400, ct);
                return;
            }

            using var stream = new FileStream(credentialsPath, FileMode.Open, FileAccess.Read);
            var credential = GoogleCredential.FromStream(stream).CreateScoped(DriveService.Scope.DriveFile);
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "BitePaper",
            });

            // Підготовка файлу
            var fileMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = req.Title ?? req.File.FileName,
                MimeType = req.File.ContentType
            };

            using var fileStream = req.File.OpenReadStream();
            var request = service.Files.Create(fileMetadata, fileStream, req.File.ContentType);
            request.Fields = "id";

            var progress = await request.UploadAsync(ct);

            if (progress.Status == UploadStatus.Completed)
            {
                // Надати доступ користувачу до файлу
                var permission = new Google.Apis.Drive.v3.Data.Permission
                {
                    Type = "user",
                    Role = "reader",
                    EmailAddress = req.UserEmail
                };
                
                var permissionRequest = service.Permissions.Create(permission, request.ResponseBody?.Id);
                await permissionRequest.ExecuteAsync(ct);
                
                // Створення документа в базі даних
                var document = new Document
                {
                    Title = req.Title ?? req.File.FileName,
                    AuthorEmail = req.UserEmail,
                    Status = new Status { Name = "Uploaded"},
                    FileId = request.ResponseBody?.Id,
                    FileType = req.File.ContentType,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                
                // Збереження документа в базі даних
                await _documentRepository.CreateAsync(document);
                
                await SendOkAsync(new { 
                    message = "Успішно завантажено в Google Drive та збережено в базі даних", 
                    documentId = document.Id,
                    fileId = request.ResponseBody?.Id,
                    viewLink = $"https://drive.google.com/file/d/{request.ResponseBody?.Id}/view",
                    accessGrantedTo = req.UserEmail
                }, ct);
            }
            else
            {
                AddError($"Upload failed with status: {progress.Status}");
                await SendErrorsAsync(500, ct);
            }
        }
        catch (Exception ex)
        {
            AddError($"Error uploading file: {ex.Message}");
            await SendErrorsAsync(500, ct);
        }
    }
}