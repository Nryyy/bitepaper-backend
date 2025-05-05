using BitePaper.Application.Queries.DocumentComments;
using BitePaper.Models.DTOs.Request.DocumentComments;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.DocumentComments
{
    public class GetDocumentCommentByIdEndpoint(IMediator mediator) : Endpoint<DeleteDocumentCommentRequest>
    {
        public override void Configure()
        {
            Get("document-comment/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteDocumentCommentRequest request, CancellationToken ct)
        {
            var documentComments = await mediator.Send(new GetDocumentCommentByIdQuery(request.Id), ct);
            await SendAsync(documentComments, cancellation: ct);
        }
    }
}
