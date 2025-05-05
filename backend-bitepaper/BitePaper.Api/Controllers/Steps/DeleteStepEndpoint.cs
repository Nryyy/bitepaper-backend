using BitePaper.Application.Commands.Documents;
using BitePaper.Application.Commands.Steps;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Steps;
    public class DeleteStepEndpoint(IMediator mediator) : Endpoint<DeleteDocumentCommand>
    {
    public override void Configure()
    {
        Delete("step/delete/{id}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(DeleteDocumentCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteStepCommand(request.id), cancellationToken);
        await SendAsync("Delete succeed!",cancellation: cancellationToken);
    }
}
