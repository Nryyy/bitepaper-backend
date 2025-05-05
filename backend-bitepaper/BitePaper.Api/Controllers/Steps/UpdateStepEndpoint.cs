using BitePaper.Application.Commands.Steps;
using BitePaper.Application.Queries.Steps;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Steps;
    public class UpdateStepEndpoint(IMediator mediator) : Endpoint<Step>
{
    public override void Configure()
    {
        Put("step/update/{id}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(Step request, CancellationToken cancellationToken)
    {
        var step = await mediator.Send(new GetStepByIdQuery(request.Id), cancellationToken);
        if (step == null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }   
        await mediator.Send(new UpdateStepCommand(request), cancellationToken);
        await SendNoContentAsync(cancellationToken);
    }
}
