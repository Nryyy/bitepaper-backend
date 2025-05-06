using BitePaper.Application.Queries.Users;
using BitePaper.Infrastructure.Interfaces.Users;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Users;

public class GetUserByEmailHandler(IUserService userService) : IRequestHandler<GetUserByEmailQuery, User?>
{
    public async Task<User?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken) =>
        await userService.GetByEmailAsync(request.Email);
}