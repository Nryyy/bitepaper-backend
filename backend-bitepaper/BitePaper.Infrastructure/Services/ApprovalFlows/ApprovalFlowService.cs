using BitePaper.Infrastructure.Interfaces.ApprovalFlows;
using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Services.ApprovalFlows;
public class ApprovalFlowService : IApprovalFlowService
{
    private readonly IApprovalFlowRepository _approvalFlowRepository;
    public ApprovalFlowService(IApprovalFlowRepository approvalFlowRepository) => _approvalFlowRepository = approvalFlowRepository;
    public async Task<List<ApprovalFlow>> GetAllAsync() => await _approvalFlowRepository.GetAllAsync();
    public async Task<ApprovalFlow?> GetByIdAsync(string id) => await _approvalFlowRepository.GetByIdAsync(id); 
    public async Task CreateAsync(ApprovalFlow approvalflow) => await _approvalFlowRepository.CreateAsync(approvalflow);
    public async Task DeleteAsync(string id) => await _approvalFlowRepository.DeleteAsync(id);
    public async Task UpdateAsync(ApprovalFlow approvalflow) => await _approvalFlowRepository.UpdateAsync(approvalflow);
}
