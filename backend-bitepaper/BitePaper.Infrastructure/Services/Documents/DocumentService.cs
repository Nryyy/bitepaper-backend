using BitePaper.Infrastructure.Interfaces.Documents;
using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Services.Documents;
public class DocumentService(IDocumentRepository documentRepository) : IDocumentService
{
    public async Task<List<Document>> GetAllAsync() =>
        await documentRepository.GetAllAsync();
    public async Task<Document?> GetByIdAsync(string id) =>
        await documentRepository.GetByIdAsync(id);
    public async Task CreateAsync(Document document) =>
        await documentRepository.CreateAsync(document);
    public async Task UpdateAsync(Document document) =>
        await documentRepository.UpdateAsync(document);
    public async Task DeleteAsync(string id) =>
        await documentRepository.DeleteAsync(id);
}