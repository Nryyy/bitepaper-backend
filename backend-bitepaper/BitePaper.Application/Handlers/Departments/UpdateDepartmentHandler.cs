using BitePaper.Application.Commands.Departments;
using BitePaper.Infrastructure.Interfaces.Departments;
using MediatR;

namespace BitePaper.Application.Handlers.Departments;

public class UpdateDepartmentHandler(IDepartmentService departmentService) : IRequestHandler<UpdateDepartmentCommand>
{
    public async Task Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken) =>
        await departmentService.UpdateAsync(request.department);
}