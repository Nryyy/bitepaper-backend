using BitePaper.Infrastructure.Interfaces.Signatures;
using MongoDB.Driver;
using BitePaper.Models.Entities;
using Microsoft.Extensions.Configuration;

namespace BitePaper.Infrastructure.Repositories.Signatures
{
    public class SignatureRepository : ISignatureRepository
    {
        private readonly IMongoCollection<Signature> _signatures;

        public SignatureRepository(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
            _signatures = database.GetCollection<Signature>("Signatures"); // Окрема колекція для підписів
        }

        public async Task<List<Signature>> GetAllAsync() =>
            await _signatures.Find(_ => true).ToListAsync();
        public async Task<Signature?> GetByIdAsync(string id) =>
            await _signatures.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Signature signature) =>
            await _signatures.InsertOneAsync(signature);
        public Task DeleteAsync(string id) =>
            _signatures.DeleteOneAsync(x => x.Id == id);
    }
}
