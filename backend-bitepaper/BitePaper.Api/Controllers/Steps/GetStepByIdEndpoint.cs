using BitePaper.Application.Queries.Steps;
using BitePaper.Models.DTOs.Request.Steps;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Steps;
    public class GetStepByIdEndpoint(IMediator mediator) : Endpoint<GetStepByIdRequest>
{
    public override void Configure()
    {
        Get("step/{id}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(GetStepByIdRequest request, CancellationToken cancellationToken)
    {
        var step = await mediator.Send(new GetStepByIdQuery(request.Id), cancellationToken);
        await SendAsync(step, cancellation: cancellationToken);
    }
}
