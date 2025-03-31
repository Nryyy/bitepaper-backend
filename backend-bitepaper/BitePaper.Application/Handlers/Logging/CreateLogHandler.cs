using BitePaper.Application.Commands.Logs;
using BitePaper.Infrastructure.Interfaces.Logs;
using MediatR;

namespace BitePaper.Application.Handlers.Logs
{
    public class CreateLogHandler : IRequestHandler<CreateLogCommand>
    {
        private readonly ILogService _logService;
        public CreateLogHandler(ILogService logService)
        {
            _logService = logService;
        }
        public async Task Handle(CreateLogCommand request, CancellationToken cancellationToken) =>
            await _logService.CreateAsync(request.log);
    }
}
