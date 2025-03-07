using MediatR;
using BitePaper.Models.Entities;

namespace BitePaper.Application.Commands.Roles
{
    public record CreateRoleCommand(Role Role) : IRequest;
}
