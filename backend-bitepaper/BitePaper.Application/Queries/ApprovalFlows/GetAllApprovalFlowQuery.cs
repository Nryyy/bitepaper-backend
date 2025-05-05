using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.ApprovalFlows;
    public record GetAllApprovalFlowQuery : IRequest<List<ApprovalFlow>>;