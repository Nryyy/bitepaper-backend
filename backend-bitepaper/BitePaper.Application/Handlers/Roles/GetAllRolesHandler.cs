using BitePaper.Application.Queries.Roles;
using BitePaper.Infrastructure.Interfaces.Roles;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Roles;
public class GetAllRolesHandler(IRoleService roleService) : IRequestHandler<GetAllRoleQuery, List<Role>>
{
    public async Task<List<Role>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken) =>
        await roleService.GetAllAsync();
}