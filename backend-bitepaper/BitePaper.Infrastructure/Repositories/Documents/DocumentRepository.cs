using BitePaper.Infrastructure.Interfaces.Documents;
using BitePaper.Models.DTOs.Request.Document;
using MongoDB.Driver;
using BitePaper.Models.Entities;
using Microsoft.Extensions.Configuration;

namespace BitePaper.Infrastructure.Repositories.Documents;
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
    public async Task<List<Document>> GetByEmailAsync(string email) =>
        await _documents.Find(x => x.AuthorEmail == email).ToListAsync();
    public async Task<List<Document>> GetByIdAsync(string id) => 
        await _documents.Find(x => x.Id == id).ToListAsync();
    public async Task CreateAsync(Document document) =>
        await _documents.InsertOneAsync(document);
    public async Task UpdateUsersWithAccessAsync(string id, List<string> usersWithAccessEmail)
    {
        var filter = Builders<Document>.Filter.Eq(d => d.Id, id);
        var update = Builders<Document>.Update.Set(d => d.UsersWithAccessEmail, usersWithAccessEmail);
        await _documents.UpdateOneAsync(filter, update);
    }


    public Task DeleteAsync(string id) =>
        _documents.DeleteOneAsync(x => x.Id == id);
}