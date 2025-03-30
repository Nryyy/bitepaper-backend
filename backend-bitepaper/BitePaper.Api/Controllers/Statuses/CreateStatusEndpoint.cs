using BitePaper.Application.Commands.Statuses;
using FastEndpoints;
using MediatR;
using BitePaper.Models.Entities;

namespace BitePaper.Api.Controllers.Statuses
{
    public class CreateStatusEndpoint(IMediator mediator) : Endpoint<Status>
    {
        public override void Configure()
        {
            Post("status/create");
            AllowAnonymous();
        }
        public override async Task HandleAsync(Status request, CancellationToken cancellationToken)
        {
            await mediator.Send(new CreateStatusCommand(request), cancellationToken);
            await SendNoContentAsync(cancellationToken);
        }
    }
}
