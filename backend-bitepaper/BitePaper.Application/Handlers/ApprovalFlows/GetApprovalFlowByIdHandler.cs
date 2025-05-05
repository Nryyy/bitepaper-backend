using BitePaper.Application.Queries.ApprovalFlows;
using BitePaper.Infrastructure.Interfaces.ApprovalFlows;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.ApprovalFlows;
    public class GetApprovalFlowByIdHandler(IApprovalFlowRepository approvalFlowRepository) : IRequestHandler<GetApprovalFlowByIdQuery, ApprovalFlow>
{
    public async Task<ApprovalFlow> Handle(GetApprovalFlowByIdQuery request, CancellationToken cancellationToken) => await approvalFlowRepository.GetByIdAsync(request.Id);
}