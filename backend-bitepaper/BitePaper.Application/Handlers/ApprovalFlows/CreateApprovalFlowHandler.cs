using BitePaper.Application.Commands.ApprovalFlows;
using BitePaper.Infrastructure.Interfaces.ApprovalFlows;
using MediatR;

namespace BitePaper.Application.Handlers.ApprovalFlows;
    public class CreateApprovalFlowHandler(IApprovalFlowService approvalFlowService) : IRequestHandler<CreateApprovalFlowCommand>
{
    public async Task Handle(CreateApprovalFlowCommand request, CancellationToken cancellationToken) => await approvalFlowService.CreateAsync(request.approvalflow);
}
