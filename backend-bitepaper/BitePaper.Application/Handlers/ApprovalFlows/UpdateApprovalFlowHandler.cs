using BitePaper.Application.Commands.ApprovalFlows;
using BitePaper.Infrastructure.Interfaces.ApprovalFlows;
using MediatR;

namespace BitePaper.Application.Handlers.ApprovalFlows;
    public class UpdateApprovalFlowHandler(IApprovalFlowService approvalFlowService) : IRequestHandler<UpdateApprovalFlowCommand>
{
    public async Task Handle(UpdateApprovalFlowCommand request, CancellationToken cancellationToken) => await approvalFlowService.UpdateAsync(request.approvalflow);
}