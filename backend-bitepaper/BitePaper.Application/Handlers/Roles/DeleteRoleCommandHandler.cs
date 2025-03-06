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
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
    {
        private readonly IRoleService _roleService;
        public DeleteRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleService.DeleteAsync(request.Id);
        }
    }
}

