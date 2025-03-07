using BitePaper.Application.Queries.Roles;
using BitePaper.Infrastructure.Interfaces.Roles;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Roles
{
    public class GetAllRolesHandler : IRequestHandler<GetAllRoleQuery, List<Role>>
    {
        private readonly IRoleService _roleService;
        public GetAllRolesHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<List<Role>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            return await _roleService.GetAllAsync();
        }
    }
}
