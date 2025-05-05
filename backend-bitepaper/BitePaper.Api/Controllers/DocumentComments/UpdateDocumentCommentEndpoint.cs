using BitePaper.Application.Queries.DocumentComments;
using BitePaper.Application.Commands.DocumentComments;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.DocumentComments
{
    public class UpdateDocumentCommentEndpoint(IMediator mediator) : Endpoint<DocumentComment>
    {
        public override void Configure()
        {
            Get("document-comment/update/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DocumentComment request, CancellationToken ct)
        {
            var documentComments = await mediator.Send(new GetDocumentCommentByIdQuery(request.Id), ct);
            if (documentComments == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            await mediator.Send(new UpdateDocumentCommentCommand(request), ct);
            await SendNoContentAsync(ct);
        }
    }
}
