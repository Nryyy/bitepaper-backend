using BitePaper.Infrastructure.Interfaces.Roles;
using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Services.Roles;
public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    public async Task<List<Role>> GetAllAsync() => await roleRepository.GetAllAsync();
    public async Task<Role?> GetByIdAsync(string id) => await roleRepository.GetByIdAsync(id);
    public async Task CreateAsync(Role role) => await roleRepository.CreateAsync(role);
    public async Task DeleteAsync(string id) => await roleRepository.DeleteAsync(id);
}