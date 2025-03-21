using BitePaper.Application.Commands.Users;
using BitePaper.Infrastructure.Interfaces.Users;
using MediatR;

namespace BitePaper.Application.Handlers.Users;

public class DeleteUserHandler(IUserService userService) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken) =>
        await userService.DeleteAsync(request.Id);
}