using BitePaper.Application.Commands.Departments;
using BitePaper.Application.Queries.Departments;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;
using MongoDB.Bson;

namespace BitePaper.Api.Controllers.Departments;

public class UpdateDepartmentEndpoint : Endpoint<Department>
{
    private readonly IMediator _mediator;

    public UpdateDepartmentEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Put("/departments-update/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Department req, CancellationToken ct)
    {
        var departmentId = Route<ObjectId>("id");
        
        var department = await _mediator.Send(new GetDepartmentByIdQuery(departmentId), ct);
        
        if (department == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        await _mediator.Send(new UpdateDepartmentCommand(req), ct);
        
        await SendNoContentAsync(ct);
    }
}