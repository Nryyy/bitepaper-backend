using BitePaper.Application.Commands.Users;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Users;
public class CreateUserEndpoint(IMediator mediator) : Endpoint<User>
{
    public override void Configure()
    {
        Post("user/create");
        AllowAnonymous();
    }
    public override async Task HandleAsync(User request, CancellationToken ct)
    {
        await mediator.Send(new CreateUserCommand(request), ct);
        await SendNoContentAsync(ct);
    }
}