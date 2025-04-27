using System;
using System.Collections.Generic;
using BitePaper.Infrastructure.Interfaces.Logs;
using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Services.Logs
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task<List<Log>> GetAllAsync() => await _logRepository.GetAllAsync();
        public async Task<Log?> GetByIdAsync(string id) => await _logRepository.GetByIdAsync(id);
        public async Task CreateAsync(Log log) => await _logRepository.CreateAsync(log);
        public async Task DeleteAsync(string id) => await _logRepository.DeleteAsync(id);
    }
}
