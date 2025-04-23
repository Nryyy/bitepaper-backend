using BitePaper.Application.Commands.Departments;
using BitePaper.Infrastructure.Interfaces.Departments;
using MediatR;

namespace BitePaper.Application.Handlers.Departments;

public class DeleteDepartmentHandler(IDepartmentService departmentService) : IRequestHandler<DeleteDepartmentCommand>
{
    public async Task Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken) =>
        await departmentService.DeleteAsync(request.id);
}