using BitePaper.Infrastructure.Interfaces.DocumentComments;
using MongoDB.Driver;
using BitePaper.Models.Entities;
using Microsoft.Extensions.Configuration;

namespace BitePaper.Infrastructure.Repositories.DocumentComments;
    public class DocumentCommentRepository : IDocumentCommentRepository
    {
        private readonly IMongoCollection<DocumentComment> _documentComments;
        public DocumentCommentRepository(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
            _documentComments = database.GetCollection<DocumentComment>("DocumentComments"); // Окрема колекція для коментарів до документів
        }
        public async Task<List<DocumentComment>> GetAllAsync() =>
            await _documentComments.Find(_ => true).ToListAsync();
        public async Task<DocumentComment?> GetByIdAsync(string id) =>
            await _documentComments.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(DocumentComment documentComment) =>
            await _documentComments.InsertOneAsync(documentComment);
        public async Task UpdateAsync(DocumentComment documentComment) =>
            await _documentComments.ReplaceOneAsync(x => x.Id == documentComment.Id, documentComment);
        public Task DeleteAsync(string id) =>
            _documentComments.DeleteOneAsync(x => x.Id == id);

    }