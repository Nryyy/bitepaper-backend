using BitePaper.Infrastructure.Interfaces.ApprovalFlows;
using MongoDB.Driver;
using BitePaper.Models.Entities;
using Microsoft.Extensions.Configuration;

namespace BitePaper.Infrastructure.Repositories.ApprovalFlows;
    public class ApprovalFlowRepository : IApprovalFlowRepository
    {
    private readonly IMongoCollection<ApprovalFlow> _approvalFlows;
    public ApprovalFlowRepository(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDB:ConnectionString"]);
        var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
        _approvalFlows = database.GetCollection<ApprovalFlow>("ApprovalFlows"); // Окрема колекція для ApprovalFlows
    }
    public async Task<List<ApprovalFlow>> GetAllAsync() =>
        await _approvalFlows.Find(_ => true).ToListAsync();
    public async Task<ApprovalFlow?> GetByIdAsync(string id) =>
        await _approvalFlows.Find(x => x.Id == id).FirstOrDefaultAsync();
    public async Task CreateAsync(ApprovalFlow approvalFlow) =>
        await _approvalFlows.InsertOneAsync(approvalFlow);
    public async Task UpdateAsync(ApprovalFlow approvalFlow) =>
        await _approvalFlows.ReplaceOneAsync(x => x.Id == approvalFlow.Id, approvalFlow);
    public Task DeleteAsync(string id) =>
        _approvalFlows.DeleteOneAsync(x => x.Id == id);

}
