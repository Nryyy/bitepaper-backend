using BitePaper.Application.Commands.Notifications;
using BitePaper.Models.Entities;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Notidications
{
    public class DeleteNotificationEndpoint (IMediator mediator) : Endpoint<Notification>
    {
        public override void Configure()
        {
            Delete("notification/delete/{Id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Notification request, CancellationToken cancellationToken)
        {
            await mediator.Send(new DeleteNotificationCommand(request.Id), cancellationToken);
            await SendNoContentAsync(cancellationToken);
        }
    }
}
