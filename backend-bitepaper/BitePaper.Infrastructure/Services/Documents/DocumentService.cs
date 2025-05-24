using BitePaper.Infrastructure.Interfaces.Documents;
using BitePaper.Models.DTOs.Request.Document;
using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Services.Documents;
public class DocumentService(IDocumentRepository documentRepository) : IDocumentService
{
    public async Task<List<Document>> GetAllAsync() =>
        await documentRepository.GetAllAsync();
    public async Task<List<Document?>> GetByEmailAsync(string email) =>
        await documentRepository.GetByEmailAsync(email);
    public async Task<List<Document?>> GetByIdAsync(string id) =>
        await documentRepository.GetByIdAsync(id);
    public async Task CreateAsync(Document document) =>
        await documentRepository.CreateAsync(document);

    public async Task UpdateUsersWithAccessAsync(string id, List<string> usersWithAccessEmail) =>
        await documentRepository.UpdateUsersWithAccessAsync(id, usersWithAccessEmail);
    
    public async Task DeleteAsync(string id) =>
        await documentRepository.DeleteAsync(id);
}