using BitePaper.Infrastructure.Interfaces.TestEntities;
using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Services.TestEnteties;

public class TestService : ITestService
{
    private readonly ITestRepository _repository;

    public TestService(ITestRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<TestEntity>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<TestEntity?> GetByIdAsync(string id) => await _repository.GetByIdAsync(id);

    public async Task CreateAsync(TestEntity test) => await _repository.CreateAsync(test);
}