using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Interfaces.Steps;
    public interface IStepRepository
    {
    Task<List<Step>> GetAllAsync();
    Task<Step?> GetByIdAsync(string id);
    Task CreateAsync(Step step);
    Task UpdateAsync(Step step);
    Task DeleteAsync(string id);
}
