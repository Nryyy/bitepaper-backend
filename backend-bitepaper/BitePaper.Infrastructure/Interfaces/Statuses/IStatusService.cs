using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Interfaces.Statuses
{
    public interface IStatusService
    {
        Task<List<Status>> GetAllAsync();
        Task<Status?> GetByIdAsync(string id);
        Task CreateAsync(Status status);
        Task DeleteAsync(string id);
    }
}
