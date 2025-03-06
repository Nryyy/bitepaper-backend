using BitePaper.Application.Queries.Departments;
using BitePaper.Infrastructure.Interfaces.Departments;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Departments;

public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, Department?>
{
    private readonly IDepartmentService _departmentService;

    public GetDepartmentByIdHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }
    
    public async Task<Department?> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken) =>
        await _departmentService.GetByIdAsync(request.id);
}