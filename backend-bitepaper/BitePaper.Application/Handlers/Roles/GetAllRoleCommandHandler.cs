using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitePaper.Application.Commands.Roles;
using BitePaper.Infrastructure.Interfaces.Roles;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Roles
{
    public class GetAllRoleCommandHandler : IRequestHandler<GetAllRoleCommand, List<Role>>
    {
        private readonly IRoleService _roleService;
        public GetAllRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<List<Role>> Handle(GetAllRoleCommand request, CancellationToken cancellationToken)
        {
            return await _roleService.GetAllAsync();
        }
    }
}
