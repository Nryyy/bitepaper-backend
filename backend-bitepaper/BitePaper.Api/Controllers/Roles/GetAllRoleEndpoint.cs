using BitePaper.Application.Commands.Roles;
using FastEndpoints;
using MediatR;
using BitePaper.Models.Entities;

namespace BitePaper.Api.Controllers.Roles
{
    public class GetAllRoleEndpoint : EndpointWithoutRequest<List<Role>>
    {
        private readonly IMediator _mediator;
        public GetAllRoleEndpoint(IMediator mediator) => _mediator = mediator;
        public override void Configure()
        {
            Get("/role-get-all");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllRoleCommand(), cancellationToken);
            await SendAsync(result);
        }
    }
}

