using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Interfaces.Notifications
{
    public interface INotificationRepository
    {
        Task<List<Notification>> GetAllAsync();
        Task<Notification?> GetByIdAsync(string id);
        Task CreateAsync(Notification notification);
        Task UpdateAsync(Notification notification);
        Task DeleteAsync(string id);
        Task<List<Notification>> GetAllByUserIdAsync(string userId);
    }
}
