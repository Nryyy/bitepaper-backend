using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Interfaces.Documents;
public interface IDocumentRepository
{
    Task<List<Document>> GetAllAsync();
    Task<Document?> GetByIdAsync(string id);
    Task CreateAsync(Document document);
    Task UpdateAsync(Document document);
    Task DeleteAsync(string id);
}