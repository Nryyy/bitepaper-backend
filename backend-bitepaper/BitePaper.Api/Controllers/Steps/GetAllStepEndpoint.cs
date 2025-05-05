using BitePaper.Application.Queries.Steps;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Steps;
    public class GetAllStepEndpoint(IMediator mediator) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("step/get-all");
        AllowAnonymous();
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var steps = await mediator.Send(new GetAllStepQuery(), cancellationToken);
        await SendAsync(steps);
    }
    }
