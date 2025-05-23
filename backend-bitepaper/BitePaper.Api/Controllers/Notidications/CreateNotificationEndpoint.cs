using BitePaper.Application.Commands.Notifications;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Notidications
{
    public class CreateNotificationEndpoint (IMediator mediator) : Endpoint<Notification>
    {
        public override void Configure()
        {
            Post("notification/create");
            AllowAnonymous();
        }
        public override async Task HandleAsync(Notification request, CancellationToken cancellationToken)
        {
            await mediator.Send(new CreateNotificationCommand(request), cancellationToken);
            await SendNoContentAsync(cancellationToken);
        }

    }
}
