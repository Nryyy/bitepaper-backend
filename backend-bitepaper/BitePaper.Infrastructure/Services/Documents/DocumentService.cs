using BitePaper.Infrastructure.Interfaces.Documents;
using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Services.Documents
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        public DocumentService(IDocumentRepository documentRepository) =>
            _documentRepository = documentRepository;
        public async Task<List<Document>> GetAllAsync() =>
            await _documentRepository.GetAllAsync();
        public async Task<Document?> GetByIdAsync(string id) =>
            await _documentRepository.GetByIdAsync(id);
        public async Task CreateAsync(Document document) =>
            await _documentRepository.CreateAsync(document);
        public async Task UpdateAsync(Document document) =>
            await _documentRepository.UpdateAsync(document);
        public async Task DeleteAsync(string id) =>
            await _documentRepository.DeleteAsync(id);
    }
}
