using BitePaper.Application.Queries.Users;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Users;

public class GetUserByIdEndpoint(IMediator mediator) : Endpoint<GetUserByIdQuery>
{
    public override void Configure()
    {
        Get("user/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var step = await mediator.Send(new GetUserByIdQuery(request.Id), cancellationToken);
        await SendAsync(step, cancellation: cancellationToken);
    }
}