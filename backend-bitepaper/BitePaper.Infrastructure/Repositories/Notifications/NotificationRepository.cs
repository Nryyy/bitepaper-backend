using BitePaper.Infrastructure.Interfaces.Notifications;
using MongoDB.Driver;
using BitePaper.Models.Entities;
using Microsoft.Extensions.Configuration;

namespace BitePaper.Infrastructure.Repositories.Notifications
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly IMongoCollection<Notification> _notifications;

        public NotificationRepository(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
            _notifications = database.GetCollection<Notification>("Notifications"); // Окрема колекція для сповіщень
        }
        public async Task<List<Notification>> GetAllAsync() =>
            await _notifications.Find(_ => true).ToListAsync();
        public async Task<Notification?> GetByIdAsync(string id) =>
            await _notifications.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Notification notification) =>
            await _notifications.InsertOneAsync(notification);
        public async Task UpdateAsync(Notification notification) =>
            await _notifications.ReplaceOneAsync(x => x.Id == notification.Id, notification);
        public Task DeleteAsync(string id) =>
            _notifications.DeleteOneAsync(x => x.Id == id);

    }
}
