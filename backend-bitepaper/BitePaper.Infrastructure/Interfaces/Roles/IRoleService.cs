using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Interfaces.Roles
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(string id);
        Task CreateAsync(Role role);
        Task DeleteAsync(string id);
    }
}
