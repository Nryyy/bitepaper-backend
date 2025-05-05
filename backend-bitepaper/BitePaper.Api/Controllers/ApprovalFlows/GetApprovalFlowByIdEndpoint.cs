using BitePaper.Application.Queries.ApprovalFlows;
using BitePaper.Models.Entities;
using BitePaper.Models.DTOs.Request.ApprovalFlows;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.ApprovalFlows;
    public class GetApprovalFlowByIdEndpoint(IMediator mediator) : Endpoint<GetApprovalFlowByIdRequest>
{
    public override void Configure()
    {
        Get("approval-flow/{id}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(GetApprovalFlowByIdRequest req, CancellationToken ct)
    {
        var result = await mediator.Send(new GetApprovalFlowByIdQuery(req.Id), ct);
        await SendAsync(result, cancellation: ct);
    }
}
