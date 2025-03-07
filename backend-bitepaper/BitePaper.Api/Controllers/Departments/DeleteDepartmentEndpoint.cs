using BitePaper.Application.Commands.Departments;
using BitePaper.Models.DTOs.Request.Department;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Departments;

public class DeleteDepartmentEndpoint(IMediator mediator) : Endpoint<DeleteDepartmentRequest>
{
    public override void Configure()
    {
        Delete("department/delete/{id}");
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(DeleteDepartmentRequest request,CancellationToken ct)
    {
        await mediator.Send(new DeleteDepartmentCommand(request.Id), ct);
        await SendNoContentAsync(ct);
    }
}