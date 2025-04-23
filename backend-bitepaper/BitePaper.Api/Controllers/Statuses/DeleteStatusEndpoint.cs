using BitePaper.Application.Commands.Statuses;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Statuses;
public class DeleteStatusEndpoint(IMediator mediator) : Endpoint<DeleteStatusCommand>
{
    public override void Configure()
    {
        Delete("status/delete/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteStatusCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteStatusCommand(request.Id), cancellationToken);
        await SendNoContentAsync(cancellationToken);
    }
}