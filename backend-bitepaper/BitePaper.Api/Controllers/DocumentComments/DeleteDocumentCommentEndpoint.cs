using BitePaper.Application.Commands.DocumentComments;
using BitePaper.Models.DTOs.Request.DocumentComments;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.DocumentComments;
    public class DeleteDocumentCommentEndpoint(IMediator mediator) : Endpoint<DeleteDocumentCommentRequest>
    {
        public override void Configure()
        {
            Delete("document-comment/delete/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteDocumentCommentRequest request, CancellationToken ct)
        {
            await mediator.Send(new DeleteDocumentCommentCommand(request.Id), ct);
            await SendAsync("Delete succeeded!", cancellation: ct);
        }
    }

    
