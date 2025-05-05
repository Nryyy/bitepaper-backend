using MediatR;

namespace BitePaper.Application.Commands.ApprovalFlows;
    public record DeleteApprovalFlowCommand(string id) : IRequest;

