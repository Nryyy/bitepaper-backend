using BitePaper.Models.Entities;
using BitePaper.Infrastructure.Interfaces.Statuses;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace BitePaper.Infrastructure.Repositories.Statuses
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }
        public async Task<List<Status>> GetAllAsync() =>
            await _statusRepository.GetAllAsync();
        public async Task<Status?> GetByIdAsync(string id) =>
            await _statusRepository.GetByIdAsync(id);

        public async Task CreateAsync(Status status) => await _statusRepository.CreateAsync(status);

        public async Task DeleteAsync(string id) => await _statusRepository.DeleteAsync(id);
    }
}
