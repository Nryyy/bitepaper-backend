using BitePaper.Models.DTOs.Request.Document;
using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Interfaces.Documents;
public interface IDocumentService
{
    Task<List<Document>> GetAllAsync();
    Task<List<Document?>> GetByEmailAsync(string email);
    Task<List<Document?>> GetByIdAsync(string id);
    Task CreateAsync(Document document);
    Task UpdateUsersWithAccessAsync(string id, List<string> usersWithAccessEmail);
    Task DeleteAsync(string id);
}