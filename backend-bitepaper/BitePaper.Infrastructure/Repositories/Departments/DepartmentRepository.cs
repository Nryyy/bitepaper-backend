using BitePaper.Infrastructure.Interfaces.Departments;
using BitePaper.Models.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BitePaper.Infrastructure.Repositories.Departments;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IMongoCollection<Department> _departments;

    public DepartmentRepository(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDB:ConnectionString"]);
        var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
        _departments = database.GetCollection<Department>("Departments"); // Окрема колекція для департаментів
    }
    
    public async Task<List<Department>> GetAllAsync() =>  
        await _departments.Find(_ => true).ToListAsync();

    public async Task<Department?> GetByIdAsync(string id) =>
        await _departments.Find(x => x.Id == id).FirstOrDefaultAsync();


    public async Task CreateAsync(Department department) =>
        await _departments.InsertOneAsync(department);

    public async Task UpdateAsync(Department department) =>
        await _departments.ReplaceOneAsync(x => x.Id == department.Id, department);

    public Task DeleteAsync(string id) =>
        _departments.DeleteOneAsync(x => x.Id == id);
}