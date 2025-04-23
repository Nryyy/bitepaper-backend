using BitePaper.Application.Commands.Roles;
using BitePaper.Infrastructure.Interfaces.Roles;
using MediatR;

namespace BitePaper.Application.Handlers.Roles;
public class CreateRoleHandler(IRoleService roleService) : IRequestHandler<CreateRoleCommand>
{
    public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken) =>
        await roleService.CreateAsync(request.Role);
}