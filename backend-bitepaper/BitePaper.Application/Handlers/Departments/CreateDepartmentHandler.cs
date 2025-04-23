using BitePaper.Application.Commands.Departments;
using BitePaper.Infrastructure.Interfaces.Departments;
using MediatR;

namespace BitePaper.Application.Handlers.Departments;

public class CreateDepartmentHandler(IDepartmentService departmentService) : IRequestHandler<CreateDepartmentCommand>
{
    public async Task Handle(CreateDepartmentCommand request, CancellationToken cancellationToken) =>
        await departmentService.CreateAsync(request.department);
}