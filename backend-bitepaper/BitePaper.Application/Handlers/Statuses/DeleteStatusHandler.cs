using BitePaper.Application.Commands.Statuses;
using BitePaper.Infrastructure.Interfaces.Statuses;
using MediatR;

namespace BitePaper.Application.Handlers.Statuses;
public class DeleteStatusHandler(IStatusService statusService) : IRequestHandler<DeleteStatusCommand>
{
    public async Task Handle(DeleteStatusCommand request, CancellationToken cancellationToken) =>
        await statusService.DeleteAsync(request.Id);
}