using BitePaper.Application.Queries.DocumentComments;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.DocumentComments
{
    public class GetAllDocumentCommentEndpoint(IMediator mediator) : EndpointWithoutRequest
    {
        public override void Configure()
        {
            Get("document-comment/get-all");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var documentComments = await mediator.Send(new GetAllDocumentCommentQuery(), ct);
            await SendAsync(documentComments);
        }
    }
}
