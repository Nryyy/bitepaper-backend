using BitePaper.Application.Commands.DocumentComments;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.DocumentComments;
    public class CreateDocumentCommentEndpoint(IMediator mediator) : Endpoint<DocumentComment>
    {
        public override void Configure()
        {
            Post("document-comment/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DocumentComment request, CancellationToken cancellationToken)
        {
            await mediator.Send(new CreateDocumentCommentCommand(request), cancellationToken);
            await SendNoContentAsync(cancellationToken);
        }
    }
