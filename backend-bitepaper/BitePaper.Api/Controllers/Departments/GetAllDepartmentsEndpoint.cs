using BitePaper.Application.Queries.Departments;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Departments;

public class GetAllDepartmentsEndpoint(IMediator mediator) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Get("department/get-all");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var departments = await mediator.Send(new GetAllDepartmentQuery(), cancellationToken);
        
        await SendAsync(departments, cancellation: cancellationToken);
    }
}