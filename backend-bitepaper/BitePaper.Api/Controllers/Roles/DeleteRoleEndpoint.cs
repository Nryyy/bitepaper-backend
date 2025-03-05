using BitePaper.Application.Commands.Roles;
using FastEndpoints;
using MediatR;
using BitePaper.Models.Entities;

namespace BitePaper.Api.Controllers.Roles
{
    public class DeleteRoleEndpoint : Endpoint<Role>
    {
        private readonly IMediator _mediator;

        public DeleteRoleEndpoint(IMediator mediator) => _mediator = mediator;
        public override void Configure()
        {
            Delete("/role-delete/{id}");
            AllowAnonymous();
        } 
        public override async Task HandleAsync(Role request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteRoleCommand(request.Id), cancellationToken);
            await SendNoContentAsync(cancellationToken);
        }
    }
}
