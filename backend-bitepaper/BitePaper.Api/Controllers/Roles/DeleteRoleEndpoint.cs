using BitePaper.Application.Commands.Roles;
using BitePaper.Models.DTOs.Request.Role;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Roles;
public class DeleteRoleEndpoint(IMediator mediator) : Endpoint<DeleteRoleRequest>
{
    public override void Configure()
    {
        Delete("role/delete/{id}");
        AllowAnonymous();
    } 
    
    public override async Task HandleAsync(DeleteRoleRequest request, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteRoleCommand(request.Id), cancellationToken);
        await SendNoContentAsync(cancellationToken);
    }
}