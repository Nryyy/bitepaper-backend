using BitePaper.Infrastructure.Interfaces.DocumentComments;
using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Services.DocumentComments;
    public class DocumentCommentService : IDocumentCommentService
    {
        private readonly IDocumentCommentRepository _documentCommentRepository;
        public DocumentCommentService(IDocumentCommentRepository documentCommentRepository) =>
            _documentCommentRepository = documentCommentRepository;
        
        public async Task<List<DocumentComment>> GetAllAsync() => await _documentCommentRepository.GetAllAsync();
        public async Task<DocumentComment?> GetByIdAsync(string id) => await _documentCommentRepository.GetByIdAsync(id);
    public async Task CreateAsync(DocumentComment documentComment) => await _documentCommentRepository.CreateAsync(documentComment);
    public async Task UpdateAsync(DocumentComment documentComment) => await _documentCommentRepository.UpdateAsync(documentComment);
    public async Task DeleteAsync(string id) => await _documentCommentRepository.DeleteAsync(id);
}

