using BitePaper.Application.Commands.Signatures;
using BitePaper.Models.DTOs.Request.Signatures;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Signatures;

public class DeleteSignatureEndpoint(IMediator mediator) : Endpoint<DeleteSignatureRequest>
{
    public override void Configure()
    {
        Delete("signature/delete/{id}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(DeleteSignatureRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteSignatureCommand(request.Id), cancellationToken);
        await SendAsync("Delete succeed!", cancellation: cancellationToken);
    }
}
