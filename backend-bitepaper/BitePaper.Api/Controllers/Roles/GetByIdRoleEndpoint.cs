using BitePaper.Application.Commands.Roles;
using FastEndpoints;
using MediatR;
using BitePaper.Models.Entities;

namespace BitePaper.Api.Controllers.Roles
{
    public class GetByIdRoleEndpoint : EndpointWithoutRequest
    {
        private readonly IMediator _mediator;
        public GetByIdRoleEndpoint(IMediator mediator) => _mediator = mediator;
        public override void Configure()
        {
            Get("/role/{id}");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var roleID = Route<string>("Id");
            var result = await _mediator.Send(new GetByIdRoleCommand(roleID), cancellationToken);
            await SendAsync(result);
        }
    }
}

