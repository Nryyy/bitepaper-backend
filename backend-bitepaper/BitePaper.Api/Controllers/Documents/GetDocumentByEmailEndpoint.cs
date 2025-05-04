using BitePaper.Application.Queries.Documents;
using BitePaper.Models.DTOs.Request.Document;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Documents;
public class GetDocumentByEmailEndpoint(IMediator mediator) : Endpoint<GetDocumentByEmailRequest>
{
    public override void Configure()
    {
        Get("document/{email}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(GetDocumentByEmailRequest request, CancellationToken ct)
    {
        var documents = await mediator.Send(new GetDocumentByEmailQuery(request.Email), ct);
        await SendAsync(documents, cancellation: ct);
    }
}