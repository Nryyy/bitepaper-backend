using BitePaper.Application.Commands.ApprovalFlows;
using BitePaper.Models.DTOs.Request.ApprovalFlows;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.ApprovalFlows;
public class DeleteApprovalFlowEndpoint(IMediator mediator) : Endpoint<GetApprovalFlowByIdRequest>
{
    public override void Configure()
    {
        Delete("approval-flow/{id}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(GetApprovalFlowByIdRequest request, CancellationToken ct)
    {
        await mediator.Send(new DeleteApprovalFlowCommand(request.Id), ct);
        await SendAsync("Delete succeed!", cancellation: ct);
    }
}
