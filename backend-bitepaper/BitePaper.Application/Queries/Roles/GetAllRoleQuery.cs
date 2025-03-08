using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Roles
{
    public record GetAllRoleQuery() : IRequest<List<Role>>;
}
