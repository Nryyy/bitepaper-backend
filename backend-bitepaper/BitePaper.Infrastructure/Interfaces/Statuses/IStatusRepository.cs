using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Interfaces.Statuses
{
    public interface IStatusRepository
    {
        Task<List<Status>> GetAllAsync();
        Task<Status?> GetByIdAsync(string id);
        Task CreateAsync(Status status);
        Task DeleteAsync(string id);
    }
}
