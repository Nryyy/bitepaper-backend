using BitePaper.Application.Commands.Documents;
using BitePaper.Application.Queries.Documents;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;
using MongoDB.Bson;

namespace BitePaper.Api.Controllers.Documents
{
    public class DeleteDocumentEndpoint : EndpointWithoutRequest
    {
        private readonly IMediator _mediator;
        public DeleteDocumentEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override void Configure()
        {
            Delete("/document-delete/{id}");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            var documentId = Route<ObjectId>("id");
            await _mediator.Send(new DeleteDocumentCommand(documentId), ct);
            await SendNoContentAsync(ct);
        }
    }
}
