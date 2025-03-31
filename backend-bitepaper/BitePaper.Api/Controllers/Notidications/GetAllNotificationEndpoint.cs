using BitePaper.Application.Queries.Notifications;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Notidications
{
    public class GetAllNotificationEndpoint(IMediator mediator) : EndpointWithoutRequest
    {
        public override void Configure()
        {
            Get("notification/all");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            var notifications = await mediator.Send(new GetAllNotificationQuery(), cancellationToken);
            await SendAsync(notifications);
        }
    }
}
