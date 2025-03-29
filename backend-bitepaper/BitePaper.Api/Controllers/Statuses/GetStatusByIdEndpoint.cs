using BitePaper.Application.Queries.Statuses;
using FastEndpoints;
using MediatR;
using BitePaper.Models.Entities;

namespace BitePaper.Api.Controllers.Statuses
{
    public class GetStatusByIdEndpoint(IMediator mediator) : Endpoint<GetStatusByIdQuery>
    {
        public override void Configure()
        {
            Get("status/{id}");
            AllowAnonymous();
        }
        public override async Task HandleAsync(GetStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetStatusByIdQuery(request.Id), cancellationToken);
            await SendAsync(result, cancellation: cancellationToken);
        }
    }
}