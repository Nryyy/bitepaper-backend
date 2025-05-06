using BitePaper.Application.Commands.Steps;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Steps;
public class CreateStepEndpoint(IMediator mediator) : Endpoint<Step>
{
    public override void Configure()
    {
        Post("step/create");
        AllowAnonymous();
    }
    public override async Task HandleAsync(Step request, CancellationToken ct)
    {
        await mediator.Send(new CreateStepCommand(request), ct);
        await SendNoContentAsync(ct);
    }
}