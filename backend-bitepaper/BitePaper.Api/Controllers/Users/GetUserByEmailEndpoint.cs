using BitePaper.Application.Queries.Users;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Users;

public class GetUserByEmailEndpoint(IMediator mediator) : Endpoint<GetUserByEmailQuery>
{
    public override void Configure()
    {
        Get("user/get-by/{email}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var step = await mediator.Send(new GetUserByEmailQuery(request.Email), cancellationToken);
        await SendAsync(step, cancellation: cancellationToken);
    }
}