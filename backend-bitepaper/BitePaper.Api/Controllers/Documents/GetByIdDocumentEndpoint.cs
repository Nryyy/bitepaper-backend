using BitePaper.Application.Commands.Documents;
using BitePaper.Application.Queries.Documents;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;
using MongoDB.Bson;

namespace BitePaper.Api.Controllers.Documents
{
    public class GetByIdDocumentEndpoint : EndpointWithoutRequest
    {
        private readonly IMediator _mediator;
        public GetByIdDocumentEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override void Configure()
        {
            Get("/document/{id}");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            var documentId = Route<ObjectId>("id");
            var document = await _mediator.Send(new GetByIdDocumentQuery(documentId), ct);
            await SendAsync(document);
        }
    }
}
