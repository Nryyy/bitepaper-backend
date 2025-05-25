using BitePaper.Application.Queries.Notifications;
using FastEndpoints;
using MediatR;

namespace BitePaper.Api.Controllers.Notidications
{
    public class GetAllNotificationByUserIdEndpoint(IMediator mediator) : Endpoint<GetAllNotificationByUserIdQuery>
    {
        public override void Configure()
        {
            Get("notification/get-by-user-id/{userId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetAllNotificationByUserIdQuery request, CancellationToken cancellationToken)
        {
            var notifications = await mediator.Send(new GetAllNotificationByUserIdQuery(request.UserId), cancellationToken);
            await SendAsync(notifications, cancellation: cancellationToken);
        }
    }

    public class GetAllNotificationByUserIdRequest
    {
        public string UserId { get; set; } = string.Empty;
    }
}
