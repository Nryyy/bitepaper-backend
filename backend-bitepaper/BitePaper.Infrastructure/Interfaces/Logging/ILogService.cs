using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Interfaces.Logs
{
    public interface ILogService
    {
        Task<List<Log>> GetAllAsync();
        Task<Log?> GetByIdAsync(string id);
        Task CreateAsync(Log log);
        Task DeleteAsync(string id);
    }
}
