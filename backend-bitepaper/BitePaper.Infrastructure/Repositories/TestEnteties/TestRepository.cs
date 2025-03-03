using BitePaper.Models.Entities;
using BitePaper.Infrastructure.Interfaces.TestEntities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BitePaper.Infrastructure.Repositories.TestEnteties;

public class TestRepository : ITestRepository
{
    private readonly IMongoCollection<TestEntity> _collection;

    public TestRepository(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDB:ConnectionString"]);
        var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
        _collection = database.GetCollection<TestEntity>(config["MongoDB:CollectionName"]);
    }

    public async Task<List<TestEntity>> GetAllAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task<TestEntity?> GetByIdAsync(string id) =>
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(TestEntity test) =>
        await _collection.InsertOneAsync(test);
}