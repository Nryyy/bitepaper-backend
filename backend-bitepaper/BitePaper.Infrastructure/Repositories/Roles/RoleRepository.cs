using BitePaper.Models.Entities;
using BitePaper.Infrastructure.Interfaces.Roles;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BitePaper.Infrastructure.Repositories.Roles;
public class RoleRepository : IRoleRepository
{
    private readonly IMongoCollection<Role> _collection;

    public RoleRepository(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDB:ConnectionString"]);
        var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
        _collection = database.GetCollection<Role>("Roles");
    }

    public async Task<List<Role>> GetAllAsync() =>
        await _collection.Find(_ => true).ToListAsync();
    public async Task<Role?> GetByIdAsync(string id) =>
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Role role) => await _collection.InsertOneAsync(role);

    public async Task DeleteAsync(string id) => await _collection.DeleteOneAsync(x => x.Id == id);
}