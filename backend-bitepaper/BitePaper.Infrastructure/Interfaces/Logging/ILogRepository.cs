using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Interfaces.Logs;

public interface ILogRepository
{
    Task<List<Log>> GetAllAsync();
    Task<Log?> GetByIdAsync(string id);
    Task CreateAsync(Log log);
    Task UpdateAsync(Log log);
    Task DeleteAsync(string id);
}
