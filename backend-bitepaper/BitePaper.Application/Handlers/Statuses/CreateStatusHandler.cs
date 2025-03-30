using BitePaper.Application.Commands.Statuses;
using BitePaper.Infrastructure.Interfaces.Statuses;
using MediatR;

namespace BitePaper.Application.Handlers.Statuses
{
    public class CreateStatusHandler : IRequestHandler<CreateStatusCommand>
    {
        private readonly IStatusService _statusService;
        public CreateStatusHandler(IStatusService statusService)
        {
            _statusService = statusService;
        }
        public async Task Handle(CreateStatusCommand request, CancellationToken cancellationToken)
        {
            await _statusService.CreateAsync(request.Status);
        }
    }
}
