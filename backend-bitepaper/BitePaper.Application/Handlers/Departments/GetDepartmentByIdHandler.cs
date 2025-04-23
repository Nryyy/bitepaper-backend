using BitePaper.Application.Queries.Departments;
using BitePaper.Infrastructure.Interfaces.Departments;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Departments;

public class GetDepartmentByIdHandler(IDepartmentService departmentService)
    : IRequestHandler<GetDepartmentByIdQuery, Department?>
{
    public async Task<Department?> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken) =>
        await departmentService.GetByIdAsync(request.id);
}