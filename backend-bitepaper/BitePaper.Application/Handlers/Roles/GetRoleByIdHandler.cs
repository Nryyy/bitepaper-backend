using BitePaper.Application.Queries.Roles;
using BitePaper.Infrastructure.Interfaces.Roles;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Roles;
public class GetRoleByIdHandler(IRoleRepository roleRepository) : IRequestHandler<GetRoleByIdQuery, Role?>
{
    public async Task<Role?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken) =>
        await roleRepository.GetByIdAsync(request.Id);
}