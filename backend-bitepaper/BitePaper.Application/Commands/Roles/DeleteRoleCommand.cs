using MediatR;
using MongoDB.Bson;

namespace BitePaper.Application.Commands.Roles
{
    public record DeleteRoleCommand(string Id) : IRequest;
}
