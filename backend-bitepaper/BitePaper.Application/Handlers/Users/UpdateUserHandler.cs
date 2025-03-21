using BitePaper.Application.Commands.Users;
using BitePaper.Infrastructure.Interfaces.Users;
using MediatR;

namespace BitePaper.Application.Handlers.Users;

public class UpdateUserHandler(IUserService userService) : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken) =>
        await userService.UpdateAsync(request.User);
}