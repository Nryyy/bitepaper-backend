using BitePaper.Application.Queries.Departments;
using BitePaper.Models.DTOs.Request.Department;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Departments;

public class GetDepartmentByIdEndpoint(IMediator mediator) : Endpoint<GetDepartmentByIdRequest>
{
    public override void Configure()
    {
        Get("department/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetDepartmentByIdRequest request,CancellationToken ct)
    {
        var department = await mediator.Send(new GetDepartmentByIdQuery(request.Id), ct);
        
        if (department == null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        await SendAsync(department, cancellation: ct);
    }
}