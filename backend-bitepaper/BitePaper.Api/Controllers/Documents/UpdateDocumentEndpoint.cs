using BitePaper.Application.Commands.Documents;
using BitePaper.Application.Queries.Documents;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;
using MongoDB.Bson;

namespace BitePaper.Api.Controllers.Documents
{
    public class UpdateDocumentEndpoint : Endpoint<Document>
    {
        private readonly IMediator _mediator;
        public UpdateDocumentEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override void Configure()
        {
            Put("/document-update/{id}");
            AllowAnonymous();
        }
        public override async Task HandleAsync(Document request, CancellationToken ct)
        {
            var documentId = Route<ObjectId>("id");
            var document = await _mediator.Send(new GetByIdDocumentQuery(documentId), ct);
            if (document == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            await _mediator.Send(new UpdateDocumentCommand(request), ct);
            await SendNoContentAsync(ct);
        }
    }
}