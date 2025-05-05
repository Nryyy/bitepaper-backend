using BitePaper.Application.Commands.Logs;
using BitePaper.Infrastructure.Interfaces.Logs;
using MediatR;

namespace BitePaper.Application.Handlers.Logs
{
    public class DeleteLogHandler : IRequestHandler<DeleteLogCommand>
    {
        private readonly ILogService _logService;
        public DeleteLogHandler(ILogService logService)
        {
            _logService = logService;
        }
        public async Task Handle(DeleteLogCommand request, CancellationToken cancellationToken) =>
            await _logService.DeleteAsync(request.id);
    }
}
