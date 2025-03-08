using BitePaper.Application.Commands.Departments;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Departments;

public class CreateDepartmentEndpoint(IMediator mediator) : Endpoint<Department>
{
    public override void Configure()
    {
        Post("department/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Department request, CancellationToken cancellationToken)
    {
        await mediator.Send(new CreateDepartmentCommand(request), cancellationToken);
        await SendNoContentAsync(cancellationToken);
    }
        
}