using BitePaper.Application.Commands.ApprovalFlows;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.ApprovalFlows;
    public class CreateApprovalFlowEndpoint(IMediator mediator) : Endpoint<ApprovalFlow>
{
    public override void Configure()
    {
        Post("approval-flow/create");
        AllowAnonymous();
    }
    public override async Task HandleAsync(ApprovalFlow request, CancellationToken cancellationToken)
    {
        await mediator.Send(new CreateApprovalFlowCommand(request), cancellationToken);
        await SendNoContentAsync(cancellationToken);
    }
}