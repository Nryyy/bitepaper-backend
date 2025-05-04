using BitePaper.Infrastructure.Interfaces.Steps;
using MongoDB.Driver;
using BitePaper.Models.Entities;
using Microsoft.Extensions.Configuration;

namespace BitePaper.Infrastructure.Repositories.Steps
{
    public class StepRepository : IStepRepository
    {
        private readonly IMongoCollection<Step> _steps;
        public StepRepository(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
            _steps = database.GetCollection<Step>("Steps"); // Окрема колекція для кроків
        }
        public async Task<List<Step>> GetAllAsync() =>
            await _steps.Find(_ => true).ToListAsync();
        public async Task<Step?> GetByIdAsync(string id) =>
            await _steps.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Step step) =>
            await _steps.InsertOneAsync(step);
        public async Task UpdateAsync(Step step) =>
            await _steps.ReplaceOneAsync(x => x.Id == step.Id, step);
        public Task DeleteAsync(string id) =>
            _steps.DeleteOneAsync(x => x.Id == id);

    }
}
