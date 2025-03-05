using BitePaper.Application.Commands.Departments;
using BitePaper.Infrastructure.Interfaces.Departments;
using MediatR;

namespace BitePaper.Application.Handlers.Departments;

public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand>
{
    private readonly IDepartmentService _departmentService;

    public UpdateDepartmentHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }
    public async Task Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken) =>
        await _departmentService.UpdateAsync(request.department);
}