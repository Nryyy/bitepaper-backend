using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
