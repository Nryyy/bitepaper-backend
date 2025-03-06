using BitePaper.Application.Queries.Departments;
using BitePaper.Infrastructure.Interfaces.Departments;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Departments;

public class GetAllDepartmentHandler : IRequestHandler<GetAllDepartmentQuery, List<Department>>
{
    private readonly IDepartmentService _departmentService;

    public GetAllDepartmentHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }
    
    public async Task<List<Department>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken) =>
        await _departmentService.GetAllAsync();
}