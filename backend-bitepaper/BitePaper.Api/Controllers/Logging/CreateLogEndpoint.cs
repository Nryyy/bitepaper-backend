using BitePaper.Application.Commands.Logs;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Logs
{
    public class CreateLogEndpoint(IMediator mediator) : Endpoint<Log>
    {
        public override void Configure()
        {
            Post("log/create");
            AllowAnonymous();
        }
        public override async Task HandleAsync(Log request, CancellationToken cancellationToken)
        {
            await mediator.Send(new CreateLogCommand(request), cancellationToken);
            await SendNoContentAsync(cancellationToken);
        }
    }
}
