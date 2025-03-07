using BitePaper.Application.Commands.Departments;
using BitePaper.Application.Queries.Departments;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Departments;

public class UpdateDepartmentEndpoint(IMediator mediator) : Endpoint<Department>
{
    public override void Configure()
    {
        Put("department/update/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Department request, CancellationToken ct)
    {
        var department = await mediator.Send(new GetDepartmentByIdQuery(request.Id), ct);
        
        if (department == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        await mediator.Send(new UpdateDepartmentCommand(request), ct);
        
        await SendNoContentAsync(ct);
    }
}