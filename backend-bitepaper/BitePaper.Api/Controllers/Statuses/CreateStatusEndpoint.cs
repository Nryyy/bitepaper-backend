using BitePaper.Application.Commands.Statuses;
using BitePaper.Models.DTOs.Request.Status;
using FastEndpoints;
using MediatR;
using BitePaper.Models.Entities;

namespace BitePaper.Api.Controllers.Statuses;
public class CreateStatusEndpoint(IMediator mediator) : Endpoint<CreateStatusDto>
{
    public override void Configure()
    {
        Post("status/create");
        AllowAnonymous();
    }
    public override async Task HandleAsync(CreateStatusDto request, CancellationToken cancellationToken)
    {
        var status = new Status { Name = request.Name };
        await mediator.Send(new CreateStatusCommand(status), cancellationToken);
        await SendNoContentAsync(cancellationToken);
    }
}