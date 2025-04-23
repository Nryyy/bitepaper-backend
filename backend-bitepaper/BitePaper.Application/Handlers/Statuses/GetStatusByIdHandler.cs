using BitePaper.Application.Queries.Statuses;
using BitePaper.Infrastructure.Interfaces.Statuses;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Statuses;
public class GetStatusByIdHandler(IStatusService statusService) : IRequestHandler<GetStatusByIdQuery, Status?>
{
    public async Task<Status?> Handle(GetStatusByIdQuery request, CancellationToken cancellationToken) =>
        await statusService.GetByIdAsync(request.Id);
}