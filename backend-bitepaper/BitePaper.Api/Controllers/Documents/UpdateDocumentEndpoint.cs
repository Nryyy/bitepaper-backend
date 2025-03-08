using BitePaper.Application.Commands.Documents;
using BitePaper.Application.Queries.Documents;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Documents
{
    public class UpdateDocumentEndpoint(IMediator mediator) : Endpoint<Document>
    {
        public override void Configure()
        {
            Put("document/update/{id}");
            AllowAnonymous();
        }
        public override async Task HandleAsync(Document request, CancellationToken ct)
        {
            var document = await mediator.Send(new GetDocumentByIdQuery(request.Id), ct);
            if (document == null)
            {
                await SendNotFoundAsync(ct);
                return;
            }
            await mediator.Send(new UpdateDocumentCommand(request), ct);
            await SendNoContentAsync(ct);
        }
    }
}