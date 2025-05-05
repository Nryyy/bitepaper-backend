using BitePaper.Application.Commands.Logs;
using BitePaper.Models.DTOs.Request.Logs;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Logs
{
    public class DeleteLogEndpoint(IMediator mediator) : Endpoint<DeleteLogRequest>
    {
        public override void Configure()
        {
            Delete("log/delete/{id}");
            AllowAnonymous();
        }
        public override async Task HandleAsync(DeleteLogRequest request, CancellationToken ct)
        {
            await mediator.Send(new DeleteLogCommand(request.Id), ct);
            await SendAsync("Delete succeed!", cancellation: ct);
        }
    }
}
