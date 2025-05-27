using BitePaper.Application.Commands.Roles;
using FastEndpoints;
using MediatR;
using BitePaper.Models.DTOs.Request.Role;

namespace BitePaper.Api.Controllers.Roles;
public class CreateRoleEndpoint(IMediator mediator) : Endpoint<CreateRoleRequest>
{
    public override void Configure()
    {
        Post("role/create");
        AllowAnonymous();
    }
    public override async Task HandleAsync(CreateRoleRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new CreateRoleCommand(request), cancellationToken);
        await SendNoContentAsync(cancellationToken);
    }
}