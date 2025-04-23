using BitePaper.Application.Commands.Documents;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Documents;
public class CreateDocumentEndpoint(IMediator mediator) : Endpoint<Document>
{
    public override void Configure()
    {
        Post("document/create");
        AllowAnonymous();
    }
    public override async Task HandleAsync(Document request, CancellationToken cancellationToken)
    {
        await mediator.Send(new CreateDocumentCommand(request), cancellationToken);
        await SendNoContentAsync(cancellationToken);
    }

}