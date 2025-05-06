using BitePaper.Application.Queries.Users;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Users;

public class GetAllUsersEndpoint(IMediator mediator) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("user/get-all");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var steps = await mediator.Send(new GetAllUsersQuery(), cancellationToken);
        await SendAsync(steps, cancellation: cancellationToken);
    }
}
