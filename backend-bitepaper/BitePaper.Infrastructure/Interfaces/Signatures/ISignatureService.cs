using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Interfaces.Signatures
{
    public interface ISignatureService
    {
        Task<List<Signature>> GetAllAsync();
        Task<Signature?> GetByIdAsync(string id);
        Task CreateAsync(Signature signature);
        Task DeleteAsync(string id);
    }
}
