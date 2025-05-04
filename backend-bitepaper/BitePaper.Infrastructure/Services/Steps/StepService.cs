using BitePaper.Infrastructure.Repositories.Steps;
using BitePaper.Infrastructure.Interfaces.Steps;
using BitePaper.Models.Entities;


namespace BitePaper.Infrastructure.Services.Steps;
    public class StepService : IStepService
{
    private readonly IStepRepository _stepRepository;
    public StepService(IStepRepository stepRepository) => _stepRepository = stepRepository;
    public async Task<List<Step>> GetAllAsync() => await _stepRepository.GetAllAsync();
    public async Task<Step?> GetByIdAsync(string id) => await _stepRepository.GetByIdAsync(id);
    
    public async Task CreateAsync(Step step)
    => await _stepRepository.CreateAsync(step);
    
    public async Task UpdateAsync(Step step)
    =>
        await _stepRepository.UpdateAsync(step);
    
    public async Task DeleteAsync(string id)
    =>
        await _stepRepository.DeleteAsync(id);
    
}
