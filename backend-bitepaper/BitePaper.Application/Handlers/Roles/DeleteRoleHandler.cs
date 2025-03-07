using BitePaper.Application.Commands.Roles;
using BitePaper.Infrastructure.Interfaces.Roles;
using MediatR;

namespace BitePaper.Application.Handlers.Roles
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand>
    {
        private readonly IRoleService _roleService;
        public DeleteRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleService.DeleteAsync(request.Id);
        }
    }
}

