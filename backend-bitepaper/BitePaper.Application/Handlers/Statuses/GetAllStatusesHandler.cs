using BitePaper.Application.Queries.Statuses;
using BitePaper.Infrastructure.Interfaces.Statuses;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Statuses;
public class GetAllStatusesHandler(IStatusService statusService)
    : IRequestHandler<GetAllStatusesQuery, List<Status>>
{
    public async Task<List<Status>> Handle(GetAllStatusesQuery request, CancellationToken cancellationToken) =>
        await statusService.GetAllAsync();
}