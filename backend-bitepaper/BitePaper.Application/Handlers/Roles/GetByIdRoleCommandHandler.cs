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
    public class GetByIdRoleCommandHandler : IRequestHandler<GetByIdRoleCommand, Role>
    {
        private readonly IRoleRepository _roleRepository;
        public GetByIdRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<Role> Handle(GetByIdRoleCommand request, CancellationToken cancellationToken)
        {

            return await _roleRepository.GetByIdAsync(request.Id);
        }
    }
}
