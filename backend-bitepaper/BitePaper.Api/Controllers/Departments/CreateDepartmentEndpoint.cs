using BitePaper.Application.Commands.Departments;
using BitePaper.Application.Queries.Departments;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Departments;

public class CreateDepartmentEndpoint : Endpoint<Department>
{
    private readonly IMediator _mediator;

    public CreateDepartmentEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public override void Configure()
    {
        Post("/create-department");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Department request, CancellationToken cancellationToken)
    {
        await _mediator.Send(new CreateDepartmentCommand(request), cancellationToken);
        await SendNoContentAsync(cancellationToken);
    }
        
}