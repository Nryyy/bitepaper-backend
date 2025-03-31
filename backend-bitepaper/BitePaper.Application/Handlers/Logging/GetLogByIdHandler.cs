using BitePaper.Application.Queries.Logs;
using BitePaper.Infrastructure.Interfaces.Logs;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Logs
{
    public class GetLogByIdHandler : IRequestHandler<GetLogByIdQuery, Log?>
    {
        private readonly ILogRepository _logRepository;
        public GetLogByIdHandler(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task<Log?> Handle(GetLogByIdQuery request, CancellationToken cancellationToken)
        {
            return await _logRepository.GetByIdAsync(request.id);
        }
    }
}
