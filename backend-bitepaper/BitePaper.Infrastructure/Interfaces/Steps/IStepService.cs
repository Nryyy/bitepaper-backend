using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Interfaces.Steps;
    public interface IStepService
    {
    Task<List<Step>> GetAllAsync();
    Task<Step?> GetByIdAsync(string id);
    Task CreateAsync(Step step);
    Task UpdateAsync(Step step);
    Task DeleteAsync(string id);
}
