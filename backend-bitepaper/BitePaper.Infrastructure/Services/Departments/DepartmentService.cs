using BitePaper.Infrastructure.Interfaces.Departments;
using BitePaper.Infrastructure.Repositories.Departments;
using BitePaper.Models.Entities;
using MongoDB.Bson;

namespace BitePaper.Infrastructure.Services.Departments;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }
    
    public async Task<List<Department>> GetAllAsync() => await _departmentRepository.GetAllAsync();
    public async Task<Department?> GetByIdAsync(ObjectId id) => await _departmentRepository.GetByIdAsync(id);
    public async Task CreateAsync(Department department) => await _departmentRepository.CreateAsync(department);
    public async Task UpdateAsync(Department department) => await _departmentRepository.UpdateAsync(department);
    public async Task DeleteAsync(ObjectId id) => await _departmentRepository.DeleteAsync(id);
}