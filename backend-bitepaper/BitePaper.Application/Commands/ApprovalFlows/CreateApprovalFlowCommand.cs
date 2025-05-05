using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Commands.ApprovalFlows;
    public record CreateApprovalFlowCommand(ApprovalFlow approvalflow) : IRequest;

