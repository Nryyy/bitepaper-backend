using BitePaper.Application.Queries.Users;
using BitePaper.Infrastructure.Interfaces.Users;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Users;

public class GetAllUsersHandler(IUserService userService) : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
{
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken) =>
        await userService.GetAllAsync();
}