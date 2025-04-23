using BitePaper.Application.Queries.Statuses;
using FastEndpoints;
using MediatR;
using BitePaper.Models.Entities;

namespace BitePaper.Api.Controllers.Statuses;
public class GetAllStatusEndpoint(IMediator mediator) : EndpointWithoutRequest<List<Status>>
{
    public override void Configure()
    {
        Get("status/get-all");
        AllowAnonymous();
    }
    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllStatusesQuery(), cancellationToken);
        await SendAsync(result);
    }
}