using BitePaper.Application.Commands.Logs;
using BitePaper.Models.DTOs.Request.Logs;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Logs;

public class CreateLogEndpoint(IMediator mediator) : Endpoint<CreateLogRequest>
{
    public override void Configure()
    {
        Post("log/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateLogRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new CreateLogCommand(request), cancellationToken);
        await SendNoContentAsync(cancellationToken);
    }
}
