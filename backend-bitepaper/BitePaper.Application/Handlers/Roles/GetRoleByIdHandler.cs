using BitePaper.Application.Queries.Roles;
using BitePaper.Infrastructure.Interfaces.Roles;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Roles
{
    public class GetRoleByIdHandler : IRequestHandler<GetRoleByIdQuery, Role>
    {
        private readonly IRoleRepository _roleRepository;
        public GetRoleByIdHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<Role> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {

            return await _roleRepository.GetByIdAsync(request.Id);
        }
    }
}
