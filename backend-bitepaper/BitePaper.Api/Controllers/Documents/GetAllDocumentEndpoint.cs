using BitePaper.Application.Commands.Documents;
using BitePaper.Application.Queries.Documents;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;
using MongoDB.Bson;

namespace BitePaper.Api.Controllers.Documents
{
    public class GetAllDocumentEndpoint(IMediator mediator) : EndpointWithoutRequest
    {
        public override void Configure()
        {
            Get("document/get-all");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            var documents = await mediator.Send(new GetAllDocumentQuery(), ct);
            await SendAsync(documents);
        }
    }
}
