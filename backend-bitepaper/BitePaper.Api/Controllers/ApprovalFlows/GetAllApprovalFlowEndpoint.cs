using BitePaper.Application.Queries.ApprovalFlows;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.ApprovalFlows;
    public class GetAllApprovalFlowEndpoint(IMediator mediator) : EndpointWithoutRequest
    {
        public override void Configure()
        {
            Get("approval-flow/get-all");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = await mediator.Send(new GetAllApprovalFlowQuery(), ct);
            await SendAsync(result);
        }
    }
