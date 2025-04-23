using BitePaper.Models.Entities;
using BitePaper.Infrastructure.Interfaces.Statuses;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BitePaper.Infrastructure.Repositories.Statuses;
public class StatusRepository : IStatusRepository
{
    private readonly IMongoCollection<Status> _collection;

    public StatusRepository(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDB:ConnectionString"]);
        var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
        _collection = database.GetCollection<Status>("Statuses");
    }
    public async Task<List<Status>> GetAllAsync() =>
        await _collection.Find(_ => true).ToListAsync();
    public async Task<Status?> GetByIdAsync(string id) =>
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Status status) => await _collection.InsertOneAsync(status);

    public async Task DeleteAsync(string id) => await _collection.DeleteOneAsync(x => x.Id == id);
}