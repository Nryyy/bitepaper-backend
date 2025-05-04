using MongoDB.Driver;
using BitePaper.Models.Entities;
using Microsoft.Extensions.Configuration;
using BitePaper.Infrastructure.Interfaces.Logs;

namespace BitePaper.Infrastructure.Repositories.Logs
{
    public class LogRepository : ILogRepository
    {
        private readonly IMongoCollection<Log> _logs;

        public LogRepository(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
            _logs = database.GetCollection<Log>("Logs"); // Окрема колекція для логів
        }
        public async Task<List<Log>> GetAllAsync() =>
            await _logs.Find(_ => true).ToListAsync();
        public async Task<Log?> GetByIdAsync(string id) =>
            await _logs.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Log log) =>
            await _logs.InsertOneAsync(log);
        public async Task UpdateAsync(Log log) =>
            await _logs.ReplaceOneAsync(x => x.Id == log.Id, log);
        public Task DeleteAsync(string id) =>
            _logs.DeleteOneAsync(x => x.Id == id);
    }
}
