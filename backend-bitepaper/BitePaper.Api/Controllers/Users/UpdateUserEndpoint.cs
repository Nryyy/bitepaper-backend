using BitePaper.Application.Commands.Users;
using BitePaper.Application.Queries.Users;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Users;

public class UpdateUserEndpoint(IMediator mediator) : Endpoint<User>
{
    public override void Configure()
    {
        Put("user/update/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(User request, CancellationToken cancellationToken)
    {
        var step = await mediator.Send(new GetUserByIdQuery(request.Id), cancellationToken);
        if (step == null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        await mediator.Send(new UpdateUserCommand(request), cancellationToken);
    }
}
