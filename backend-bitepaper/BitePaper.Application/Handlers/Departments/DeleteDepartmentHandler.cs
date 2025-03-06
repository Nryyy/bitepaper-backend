using BitePaper.Application.Commands.Departments;
using BitePaper.Infrastructure.Interfaces.Departments;
using MediatR;

namespace BitePaper.Application.Handlers.Departments;

public class DeleteDepartmentHandler: IRequestHandler<DeleteDepartmentCommand>
{
    private readonly IDepartmentService _departmentService;

    public DeleteDepartmentHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }
    
    public async Task Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken) =>
        await _departmentService.DeleteAsync(request.id);
}