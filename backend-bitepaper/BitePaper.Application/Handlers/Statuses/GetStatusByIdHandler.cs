using BitePaper.Application.Queries.Statuses;
using BitePaper.Infrastructure.Interfaces.Statuses;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Statuses
{
    public class GetStatusByIdHandler : IRequestHandler<GetStatusByIdQuery, Status>
    {
        private readonly IStatusService _statusService;
        public GetStatusByIdHandler(IStatusService statusService)
        {
            _statusService = statusService;
        }
        public async Task<Status> Handle(GetStatusByIdQuery request, CancellationToken cancellationToken)
        {
            return await _statusService.GetByIdAsync(request.Id);
        }
    }
}