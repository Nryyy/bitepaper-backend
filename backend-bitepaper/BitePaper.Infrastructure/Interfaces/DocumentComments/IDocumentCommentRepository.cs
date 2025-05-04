using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Interfaces.DocumentComments;
    public interface IDocumentCommentRepository
    {
        Task<List<DocumentComment>> GetAllAsync();
        Task<DocumentComment?> GetByIdAsync(string id);
        Task CreateAsync(DocumentComment documentComment);
        Task UpdateAsync(DocumentComment documentComment);
        Task DeleteAsync(string id);
    }

