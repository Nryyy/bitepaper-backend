using BitePaper.Application.Queries.Signatures;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Signatures;

public class GetAllSignaturesEndpoint(IMediator mediator) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("signature/get-all");
        AllowAnonymous();
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var signatures = await mediator.Send(new GetAllSignaturesQuery(), cancellationToken);
        await SendAsync(signatures);
    }
}
