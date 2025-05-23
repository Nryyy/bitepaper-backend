using BitePaper.Application.Queries.Notifications;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Notidications
{
    public class GetNotificationByIdEndpoint(IMediator mediator) : Endpoint<GetNotificationByIdQuery>
    {
        public override void Configure()
        {
            Get("notification/{id}");
            AllowAnonymous();
        }
        public override async Task HandleAsync(GetNotificationByIdQuery request, CancellationToken cancellationToken)
        {
            var notification = await mediator.Send(new GetNotificationByIdQuery(request.Id), cancellationToken);
            await SendAsync(notification, cancellation: cancellationToken);
        }
    }
}
