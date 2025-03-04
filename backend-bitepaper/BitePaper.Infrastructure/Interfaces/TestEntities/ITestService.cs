using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Interfaces.TestEntities;

public interface ITestService
{
    Task<List<TestEntity>> GetAllAsync();
    Task<TestEntity?> GetByIdAsync(string id);
    Task CreateAsync(TestEntity test);
}