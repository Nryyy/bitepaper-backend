using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Interfaces.Documents;
public interface IDocumentService
{
    Task<List<Document>> GetAllAsync();
    Task<List<Document?>> GetByEmailAsync(string email);
    Task CreateAsync(Document document);
    Task UpdateAsync(Document document);
    Task DeleteAsync(string id);
}