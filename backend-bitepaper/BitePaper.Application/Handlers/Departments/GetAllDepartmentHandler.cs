using BitePaper.Application.Queries.Departments;
using BitePaper.Infrastructure.Interfaces.Departments;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Departments;

public class GetAllDepartmentHandler(IDepartmentService departmentService)
    : IRequestHandler<GetAllDepartmentQuery, List<Department>>
{
    public async Task<List<Department>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken) =>
        await departmentService.GetAllAsync();
}