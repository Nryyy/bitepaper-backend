using BitePaper.Application.Commands.Roles;
using BitePaper.Infrastructure.Interfaces.Roles;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Roles;
public class CreateRoleHandler : IRequestHandler<CreateRoleCommand>
{
    private readonly IRoleService _roleService;
    public CreateRoleHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }
    public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = new Role
        {
            Name = request.Role.Name,
        };
        await _roleService.CreateAsync(role);
    }
}