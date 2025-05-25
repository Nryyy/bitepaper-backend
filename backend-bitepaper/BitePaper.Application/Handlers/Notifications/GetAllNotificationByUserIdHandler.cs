using BitePaper.Application.Queries.Notifications;
using BitePaper.Infrastructure.Interfaces.Notifications;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Notifications
{
    public class GetAllNotificationByUserIdHandler : IRequestHandler<GetAllNotificationByUserIdQuery, List<Notification>>
    {
        private readonly INotificationService _notificationService;

        public GetAllNotificationByUserIdHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<List<Notification>> Handle(GetAllNotificationByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _notificationService.GetAllByUserIdAsync(request.UserId);
        }
    }
}
