using BitePaper.Application.Queries.Logs;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Logs
{
    public class GetAllLogEndpoint(IMediator mediator) : EndpointWithoutRequest
    {
        public override void Configure()
        {
            Get("log/get-all");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            var logs = await mediator.Send(new GetAllLogQuery(), ct);
            await SendAsync(logs);
        }
    }
}
