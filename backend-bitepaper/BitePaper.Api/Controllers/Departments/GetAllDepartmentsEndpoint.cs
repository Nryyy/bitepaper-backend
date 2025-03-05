using BitePaper.Application.Queries.Departments;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Departments;

public class GetAllDepartmentsEndpoint : EndpointWithoutRequest<List<Department>>
{
    private readonly IMediator _mediator;

    public GetAllDepartmentsEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Get("/departments");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        // Отримуємо список департаментів через MediatR
        var departments = await _mediator.Send(new GetAllDepartmentQuery(), cancellationToken);

        // Повертаємо отримані департаменти
        await SendAsync(departments);
    }
}