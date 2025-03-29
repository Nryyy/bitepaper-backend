using BitePaper.Application.Commands.Statuses;
using BitePaper.Infrastructure.Interfaces.Statuses;
using MediatR;

namespace BitePaper.Application.Handlers.Statuses
{
    public class DeleteStatusHandler : IRequestHandler<DeleteStatusCommand>
    {
        private readonly IStatusService _statusService;
        public DeleteStatusHandler(IStatusService statusService)
        {
            _statusService = statusService;
        }
        public async Task Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            await _statusService.DeleteAsync(request.Id);
        }
    }
}
