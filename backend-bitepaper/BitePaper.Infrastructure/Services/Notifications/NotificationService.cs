using BitePaper.Infrastructure.Interfaces.Notifications;
using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Services.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        public NotificationService(INotificationRepository notificationRepository) =>
            _notificationRepository = notificationRepository;
        public async Task<List<Notification>> GetAllAsync() =>
            await _notificationRepository.GetAllAsync();
        public async Task<Notification?> GetByIdAsync(string id) =>
            await _notificationRepository.GetByIdAsync(id);
        public async Task CreateAsync(Notification notification) =>
            await _notificationRepository.CreateAsync(notification);
        public async Task UpdateAsync(Notification notification) =>
            await _notificationRepository.UpdateAsync(notification);
        public async Task DeleteAsync(string id) =>
            await _notificationRepository.DeleteAsync(id);
        public async Task<List<Notification>> GetAllByUserIdAsync(string userId) =>
                        await _notificationRepository.GetAllByUserIdAsync(userId);

    }
}
