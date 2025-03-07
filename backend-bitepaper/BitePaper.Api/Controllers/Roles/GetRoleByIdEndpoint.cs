using BitePaper.Application.Queries.Roles;
using BitePaper.Models.DTOs.Request.Role;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Roles
{
    public class GetRoleByIdEndpoint(IMediator mediator) : Endpoint<GetRoleByIdRequest>
    {
        public override void Configure()
        {
            Get("role/{id}");
            AllowAnonymous();
        }
        public override async Task HandleAsync(GetRoleByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetRoleByIdQuery(request.Id), cancellationToken);
            await SendAsync(result, cancellation: cancellationToken);
        }
    }
}

