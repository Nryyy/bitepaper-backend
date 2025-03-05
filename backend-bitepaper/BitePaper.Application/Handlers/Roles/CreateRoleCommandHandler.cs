using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitePaper.Application.Commands.Roles;
using BitePaper.Infrastructure.Interfaces.Roles;
using MediatR;

namespace BitePaper.Application.Handlers.Roles
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand>
    {
        private readonly IRoleService _roleService;
        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleService.CreateAsync(request.Role);
        }
    }
}
