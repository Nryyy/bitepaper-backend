using BitePaper.Application.Commands.Roles;
using BitePaper.Infrastructure.Interfaces.Roles;
using MediatR;

namespace BitePaper.Application.Handlers.Roles
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand>
    {
        private readonly IRoleService _roleService;
        public CreateRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleService.CreateAsync(request.Role);
        }
    }
}
