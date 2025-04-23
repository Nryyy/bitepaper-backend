using BitePaper.Models.Entities;
using BitePaper.Infrastructure.Interfaces.Statuses;

namespace BitePaper.Infrastructure.Services.Statuses;
public class StatusService(IStatusRepository statusRepository) : IStatusService
{
    public async Task<List<Status>> GetAllAsync() =>
        await statusRepository.GetAllAsync();
    public async Task<Status?> GetByIdAsync(string id) =>
        await statusRepository.GetByIdAsync(id);

    public async Task CreateAsync(Status status) => await statusRepository.CreateAsync(status);

    public async Task DeleteAsync(string id) => await statusRepository.DeleteAsync(id);
}