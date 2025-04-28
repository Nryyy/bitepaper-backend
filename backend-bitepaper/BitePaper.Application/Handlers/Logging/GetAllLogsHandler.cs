using BitePaper.Application.Queries.Logs;
using BitePaper.Infrastructure.Interfaces.Logs;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Logs;

public class GetAllLogsHandler : IRequestHandler<GetAllLogQuery, List<Log>>
{
    private readonly ILogRepository _logRepository;
    public GetAllLogsHandler(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }
    public async Task<List<Log>> Handle(GetAllLogQuery request, CancellationToken cancellationToken)
    {
        return await _logRepository.GetAllAsync();
    }
}
