using BitePaper.Infrastructure.Interfaces.Signatures;
using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Services.Signatures
{
    public class SignatureService : ISignatureService
    {
        private readonly ISignatureRepository _signatureRepository;
        public SignatureService(ISignatureRepository signatureRepository)
        {
            _signatureRepository = signatureRepository;
        }
        public Task<List<Signature>> GetAllAsync()
        {
            return _signatureRepository.GetAllAsync();
        }
        public Task<Signature?> GetByIdAsync(string id)
        {
            return _signatureRepository.GetByIdAsync(id);
        }
        public Task CreateAsync(Signature signature)
        {
            return _signatureRepository.CreateAsync(signature);
        }
        public Task DeleteAsync(string id)
        {
            return _signatureRepository.DeleteAsync(id);
        }
    }
}

