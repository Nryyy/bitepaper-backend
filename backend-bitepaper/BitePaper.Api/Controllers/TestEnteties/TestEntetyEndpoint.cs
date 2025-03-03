using BitePaper.Application.Commands.TestEnteties;
using FastEndpoints;
using MediatR;
using BitePaper.Application.Handlers.TestEnteties;
using BitePaper.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BitePaper.Api.Controllers.TestEnteties;

public class TestEntetyEndpoint : Endpoint<TestEntity>
{
    private readonly IMediator _mediator;
    
    public TestEntetyEndpoint(IMediator mediator) => _mediator = mediator;

    public override void Configure()
    {
        Post("/testEnteties");
        AllowAnonymous();
    }

    public override async Task HandleAsync(TestEntity request, CancellationToken cancellationToken)
    {
        await _mediator.Send(new CreateTestEntetyCommand(request), cancellationToken);
        await SendNoContentAsync(cancellationToken);
    }
}