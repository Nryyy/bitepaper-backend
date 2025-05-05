using BitePaper.Application.Commands.ApprovalFlows;
using BitePaper.Application.Queries.ApprovalFlows;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.ApprovalFlows;
    public class UpdateApprovalFlowEndpoint(IMediator mediator) : Endpoint<ApprovalFlow>
    {
    public override void Configure()
    {
        Put("approval-flow/update/{id}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(ApprovalFlow request, CancellationToken ct)
    {
        var flow = await mediator.Send(new GetApprovalFlowByIdQuery(request.Id),ct);
        if (flow == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        await mediator.Send(new UpdateApprovalFlowCommand(request), ct);
        await SendOkAsync(ct);
    }
}