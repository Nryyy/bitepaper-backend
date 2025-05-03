using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BitePaper.Models.DTOs.Request.Document;

public class UploadDocumentRequest
{
    public IFormFile File { get; set; }
    public string Title { get; set; }
    public string DocumentType { get; set; }
    
    [Required(ErrorMessage = "Email is required for granting access to the file")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string UserEmail { get; set; }
}
