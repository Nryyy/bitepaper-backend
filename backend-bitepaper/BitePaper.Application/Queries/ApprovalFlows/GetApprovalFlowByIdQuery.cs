using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.ApprovalFlows;
    public record GetApprovalFlowByIdQuery(string Id) : IRequest<ApprovalFlow>;