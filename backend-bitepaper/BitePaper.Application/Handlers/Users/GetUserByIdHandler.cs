using BitePaper.Application.Queries.Users;
using BitePaper.Infrastructure.Interfaces.Users;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Users;

public class GetUserByIdHandler(IUserService userService) : IRequestHandler<GetUserByIdQuery, User?>
{
    public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) =>
        await userService.GetByIdAsync(request.Id);
}