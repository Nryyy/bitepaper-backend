using BitePaper.Application.Commands.Logs;
using BitePaper.Infrastructure.Interfaces.Logs;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Logs;

public class CreateLogHandler : IRequestHandler<CreateLogCommand>
{
    private readonly ILogService _logService;

    public CreateLogHandler(ILogService logService)
    {
        _logService = logService;
    }

    public async Task Handle(CreateLogCommand request, CancellationToken cancellationToken)
    {
        var log = new Log
        {
            UserId = request.Request.UserId,
            Action = request.Request.Action,
            Details = request.Request.Details
        };

        await _logService.CreateAsync(log);
    }
}
