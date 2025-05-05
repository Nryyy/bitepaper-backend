using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Interfaces.ApprovalFlows;
    public interface IApprovalFlowService
    {
    Task<List<ApprovalFlow>> GetAllAsync();
    Task<ApprovalFlow?> GetByIdAsync(string id);
    Task CreateAsync(ApprovalFlow approvalFlow);
    Task UpdateAsync(ApprovalFlow approvalFlow);
    Task DeleteAsync(string id);
}
