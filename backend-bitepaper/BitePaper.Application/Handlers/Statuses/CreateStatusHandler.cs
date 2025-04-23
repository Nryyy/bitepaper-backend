using BitePaper.Application.Commands.Statuses;
using BitePaper.Infrastructure.Interfaces.Statuses;
using MediatR;

namespace BitePaper.Application.Handlers.Statuses;
public class CreateStatusHandler(IStatusService statusService) : IRequestHandler<CreateStatusCommand>
{
    public async Task Handle(CreateStatusCommand request, CancellationToken cancellationToken) =>
        await statusService.CreateAsync(request.Status);
}