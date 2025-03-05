using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitePaper.Infrastructure.Interfaces.Roles;
using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<List<Role>> GetAllAsync() => await _roleRepository.GetAllAsync();
        public async Task<Role?> GetByIdAsync(int id) => await _roleRepository.GetByIdAsync(id);
        public async Task CreateAsync(Role role) => await _roleRepository.CreateAsync(role);
        public async Task DeleteAsync(int id) => await _roleRepository.DeleteAsync(id);
    }
}
