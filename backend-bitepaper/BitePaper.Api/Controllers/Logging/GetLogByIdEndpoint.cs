using BitePaper.Application.Queries.Logs;
using BitePaper.Models.DTOs.Request.Logs;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Logs;

public class GetLogByIdEndpoint(IMediator mediator) : Endpoint<DeleteLogRequest>
{
    public override void Configure()
    {
        Get("log/{id}");
        AllowAnonymous();
    }
    public override async Task HandleAsync(DeleteLogRequest request, CancellationToken ct)
    {
        var logs = await mediator.Send(new GetLogByIdQuery(request.Id), ct);
        await SendAsync(logs, cancellation: ct);
    }
}
