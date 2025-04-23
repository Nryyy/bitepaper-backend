using BitePaper.Infrastructure.Interfaces.Departments;
using BitePaper.Models.Entities;

namespace BitePaper.Infrastructure.Services.Departments;

public class DepartmentService(IDepartmentRepository departmentRepository) : IDepartmentService
{
    public async Task<List<Department>> GetAllAsync() => await departmentRepository.GetAllAsync();
    public async Task<Department?> GetByIdAsync(string id) => await departmentRepository.GetByIdAsync(id);
    public async Task CreateAsync(Department department) => await departmentRepository.CreateAsync(department);
    public async Task UpdateAsync(Department department) => await departmentRepository.UpdateAsync(department);
    public async Task DeleteAsync(string id) => await departmentRepository.DeleteAsync(id);
}