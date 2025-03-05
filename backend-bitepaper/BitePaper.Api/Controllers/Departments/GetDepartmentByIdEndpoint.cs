using BitePaper.Application.Queries.Departments;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;
using MongoDB.Bson;

namespace BitePaper.Api.Controllers.Departments;

public class GetDepartmentByIdEndpoint : EndpointWithoutRequest
{
    private readonly IMediator _mediator;

    public GetDepartmentByIdEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Get("/department/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var departmentId = Route<ObjectId>("id");
        
        var department = await _mediator.Send(new GetDepartmentByIdQuery(departmentId), ct);
        
        if (department == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        await SendAsync(department, cancellation: ct);
    }
}