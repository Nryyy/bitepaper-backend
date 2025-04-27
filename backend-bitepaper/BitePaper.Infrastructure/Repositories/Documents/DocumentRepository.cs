using BitePaper.Infrastructure.Interfaces.Documents;
using MongoDB.Driver;
using BitePaper.Models.Entities;
using Microsoft.Extensions.Configuration;

namespace BitePaper.Infrastructure.Repositories.Documents
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly IMongoCollection<Document> _documents;

        public DocumentRepository(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
            _documents = database.GetCollection<Document>("Documents"); // Окрема колекція для документів
        }
        public async Task<List<Document>> GetAllAsync() =>
            await _documents.Find(_ => true).ToListAsync();
        public async Task<Document?> GetByIdAsync(string id) =>
            await _documents.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Document document) =>
            await _documents.InsertOneAsync(document);
        public async Task UpdateAsync(Document document) =>
            await _documents.ReplaceOneAsync(x => x.Id == document.Id, document);
        public Task DeleteAsync(string id) =>
            _documents.DeleteOneAsync(x => x.Id == id);
    }
}
