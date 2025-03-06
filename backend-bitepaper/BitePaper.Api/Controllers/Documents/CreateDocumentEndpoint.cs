using BitePaper.Application.Commands.Documents;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Documents
{
    public class CreateDocumentEndpoint : Endpoint<Document>
    {
        private readonly IMediator _mediator;
        public CreateDocumentEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Post("/create-document");
            AllowAnonymous();
        }
        public override async Task HandleAsync(Document request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CreateDocumentCommand(request), cancellationToken);
            await SendNoContentAsync(cancellationToken);
        }

    }
}

