using BitePaper.Application.Commands.Users;
using BitePaper.Infrastructure.Interfaces.Users;
using MediatR;

namespace BitePaper.Application.Handlers.Users;

public class CreateUserHandler(IUserService userService) : IRequestHandler<CreateUserCommand>
{
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken) =>
        await userService.AddAsync(request.User);
}