using BitePaper.Infrastructure.Interfaces.Users;
using BitePaper.Models.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BitePaper.Infrastructure.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _collection;

    public UserRepository(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDB:ConnectionString"]);
        var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
        _collection = database.GetCollection<User>("Users");
    }

    public async Task<User?> GetByIdAsync(string id) =>
        await _collection.Find(u => u.Id == id).FirstOrDefaultAsync();

    public async Task<IEnumerable<User>> GetAllAsync() =>
        await _collection.Find(_ => true).ToListAsync();

    public async Task AddAsync(User user) =>
        await _collection.InsertOneAsync(user);

    public async Task UpdateAsync(User user) =>
        await _collection.ReplaceOneAsync(u => u.Id == user.Id, user);

    public async Task DeleteAsync(string id) =>
        await _collection.DeleteOneAsync(u => u.Id == id);
}