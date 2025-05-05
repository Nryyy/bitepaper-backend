using BitePaper.Application.Queries.ApprovalFlows;
using BitePaper.Infrastructure.Interfaces.ApprovalFlows;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.ApprovalFlows;
    public class GetAllApprovalFlowHandler(IApprovalFlowService approvalFlowService) : IRequestHandler<GetAllApprovalFlowQuery, List<ApprovalFlow>>
{
    public async Task<List<ApprovalFlow>> Handle(GetAllApprovalFlowQuery request, CancellationToken cancellationToken) => await approvalFlowService.GetAllAsync();
}