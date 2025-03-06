using BitePaper.Application.Commands.Roles;
using FastEndpoints;
using MediatR;
using BitePaper.Models.Entities;

namespace BitePaper.Api.Controllers.Roles
{
    public class CreateRoleEndpoint : Endpoint<Role>
    {
        private readonly IMediator _mediator;

        public CreateRoleEndpoint(IMediator mediator) => _mediator = mediator;
        public override void Configure()
        {
            Post("/role-create");
            AllowAnonymous();
        }
        public override async Task HandleAsync(Role request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CreateRoleCommand(request), cancellationToken);
            await SendNoContentAsync(cancellationToken);
        }
    }
}
