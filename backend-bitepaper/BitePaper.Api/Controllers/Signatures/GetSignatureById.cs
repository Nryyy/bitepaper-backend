using BitePaper.Application.Queries.Signatures;
using BitePaper.Models.DTOs.Request.Signatures;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Signatures
{
    public class GetSignatureById(IMediator mediator) : Endpoint<DeleteSignatureRequest>
    {
        public override void Configure()
        {
            Get("signature/{id}");
            AllowAnonymous();
        }
        public override async Task HandleAsync(DeleteSignatureRequest request, CancellationToken cancellationToken)
        {
            var signature = await mediator.Send(new GetSignatureByIdQuery(request.Id), cancellationToken);
            await SendAsync(signature, cancellation: cancellationToken);
        }
    }
}
