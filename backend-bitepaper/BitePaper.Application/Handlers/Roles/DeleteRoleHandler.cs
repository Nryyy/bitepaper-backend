using BitePaper.Application.Commands.Roles;
using BitePaper.Infrastructure.Interfaces.Roles;
using MediatR;

namespace BitePaper.Application.Handlers.Roles;
public class DeleteRoleHandler(IRoleService roleService) : IRequestHandler<DeleteRoleCommand>
{
    public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken) =>
        await roleService.DeleteAsync(request.Id);
}