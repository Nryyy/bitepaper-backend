using BitePaper.Application.Commands.ApprovalFlows;
using BitePaper.Infrastructure.Interfaces.ApprovalFlows;
using MediatR;

namespace BitePaper.Application.Handlers.ApprovalFlows;
    public class DeleteApprovalFlowHandler(IApprovalFlowService approvalFlowService) : IRequestHandler<DeleteApprovalFlowCommand>
{
    public async Task Handle(DeleteApprovalFlowCommand request, CancellationToken cancellationToken) => await approvalFlowService.DeleteAsync(request.id);
}

