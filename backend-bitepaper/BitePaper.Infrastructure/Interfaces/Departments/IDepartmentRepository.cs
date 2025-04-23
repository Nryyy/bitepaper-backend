using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Interfaces.Departments;

public interface IDepartmentRepository
{
    Task<List<Department>> GetAllAsync();
    Task<Department?> GetByIdAsync(string id);
    Task CreateAsync(Department department);
    Task UpdateAsync(Department department);
    Task DeleteAsync(string id);
}