using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Statuses
{
    public record GetAllStatusesQuery() : IRequest<List<Status>>;
}
