using BitePaper.Application.Queries.Documents;
using BitePaper.Models.DTOs.Request.Document;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Documents
{
    public class GetDocumentByIdEndpoint(IMediator mediator) : Endpoint<GetDocumentByIdRequest>
    {
        public override void Configure()
        {
            Get("document/{id}");
            AllowAnonymous();
        }
        public override async Task HandleAsync(GetDocumentByIdRequest request, CancellationToken ct)
        {
            var documents = await mediator.Send(new GetDocumentByIdQuery(request.Id), ct);
            await SendAsync(documents, cancellation: ct);
        }
    }
}