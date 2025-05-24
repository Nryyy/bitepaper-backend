using BitePaper.Application.Commands.Documents;
using BitePaper.Application.Queries.Documents;
using BitePaper.Models.DTOs.Request.Document;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Documents;
public class UpdateDocumentEndpoint(IMediator mediator) : Endpoint<UpdateDocumetRequest>
{
    public override void Configure()
    {
        Put("document/update/{id}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(UpdateDocumetRequest request, CancellationToken ct)
    {
        var document = await mediator.Send(new GetByIdQuery(request.Id), ct);
        if (document == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        await mediator.Send(new UpdateDocumentCommand(request.Id, request.UsersWithAccessEmail), ct);
        await SendNoContentAsync(ct);
    }
}