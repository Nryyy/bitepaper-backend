using BitePaper.Application.Commands.Signatures;
using BitePaper.Models.DTOs.Request.Signatures;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Signatures;

public class CreateSignatureEndpoint(IMediator mediator) : Endpoint<CreateSignatureRequest>
{
    public override void Configure()
    {
        Post("signature/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateSignatureRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new CreateSignatureCommand(request), cancellationToken);
        await SendNoContentAsync(cancellationToken);
    }
}
