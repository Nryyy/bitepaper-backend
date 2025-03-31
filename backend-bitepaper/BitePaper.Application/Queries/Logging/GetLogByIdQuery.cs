using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Logs
{
    public record GetLogByIdQuery(string id) : IRequest<Log?>;
}
