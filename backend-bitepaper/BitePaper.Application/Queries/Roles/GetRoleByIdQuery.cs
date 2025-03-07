using BitePaper.Models.Entities;
using MediatR;
using MongoDB.Bson;

namespace BitePaper.Application.Queries.Roles
{
    public record GetRoleByIdQuery(string Id) : IRequest<Role>;
}
