using BitePaper.Application.Queries.Statuses;
using BitePaper.Infrastructure.Interfaces.Statuses;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Statuses
{
    public class GetAllStatusesHandler : IRequestHandler<GetAllStatusesQuery, List<Status>>
    {
        private readonly IStatusService _statusService;
        public GetAllStatusesHandler(IStatusService statusService)
        {
            _statusService = statusService;
        }
        public async Task<List<Status>> Handle(GetAllStatusesQuery request, CancellationToken cancellationToken)
        {
            return await _statusService.GetAllAsync();
        }
    }
}
