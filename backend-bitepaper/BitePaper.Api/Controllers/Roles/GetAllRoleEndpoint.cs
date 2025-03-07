using BitePaper.Application.Queries.Roles;
using FastEndpoints;
using MediatR;
using BitePaper.Models.Entities;

namespace BitePaper.Api.Controllers.Roles
{
    public class GetAllRoleEndpoint(IMediator mediator) : EndpointWithoutRequest<List<Role>>
    {
        public override void Configure()
        {
            Get("role/get-all");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetAllRoleQuery(), cancellationToken);
            await SendAsync(result);
        }
    }
}

