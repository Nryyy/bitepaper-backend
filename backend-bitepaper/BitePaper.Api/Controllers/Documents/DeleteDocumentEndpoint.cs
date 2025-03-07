using BitePaper.Application.Commands.Documents;
using BitePaper.Application.Queries.Documents;
using BitePaper.Models.DTOs.Request.Department;
using BitePaper.Models.DTOs.Request.Document;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;
using MongoDB.Bson;

namespace BitePaper.Api.Controllers.Documents
{
    public class DeleteDocumentEndpoint(IMediator mediator) : Endpoint<DeleteDocumentRequest>
    {
        public override void Configure()
        {
            Delete("document/delete/{id}");
            AllowAnonymous();
        }
        public override async Task HandleAsync(DeleteDocumentRequest request,CancellationToken ct)
        {
            await mediator.Send(new DeleteDocumentCommand(request.Id), ct);
            await SendAsync("Delete succeed!", cancellation: ct);
        }
    }
}
