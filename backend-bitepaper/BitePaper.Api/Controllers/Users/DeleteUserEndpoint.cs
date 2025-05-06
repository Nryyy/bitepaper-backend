using BitePaper.Application.Commands.Users;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Users;

public class DeleteUserEndpoint(IMediator mediator) : Endpoint<DeleteUserCommand>
{
    public override void Configure()
    {
        Delete("user/delete/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteUserCommand(request.Id), cancellationToken);
        await SendAsync("Delete succeed!", cancellation: cancellationToken);
    }
}