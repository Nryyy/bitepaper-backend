using BitePaper.Application.Commands.Departments;
using BitePaper.Infrastructure.Interfaces.Departments;
using BitePaper.Infrastructure.Services.Departments;
using MediatR;

namespace BitePaper.Application.Handlers.Departments;

public class CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand>
{
    private readonly IDepartmentService _departmentService;

    public CreateDepartmentHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }
    
    public async Task Handle(CreateDepartmentCommand request, CancellationToken cancellationToken) =>
        await _departmentService.CreateAsync(request.department);
}