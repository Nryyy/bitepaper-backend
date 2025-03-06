using BitePaper.Application.Commands.Documents;
using BitePaper.Application.Queries.Documents;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;
using MongoDB.Bson;

namespace BitePaper.Api.Controllers.Documents
{
    public class GetAllDocumentEndpoint : EndpointWithoutRequest
    {
        private readonly IMediator _mediator;
        public GetAllDocumentEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override void Configure()
        {
            Get("/documents");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            var documents = await _mediator.Send(new GetAllDocumentQuery(), ct);
            await SendAsync(documents);
        }
    }
}
