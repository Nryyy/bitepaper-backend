using BitePaper.Application.Queries.Notifications;
using BitePaper.Infrastructure.Interfaces.Notifications;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Notifications
{
    public class GetAllNotificationHandler : IRequestHandler<GetAllNotificationQuery, List<Notification>>
    {
        private readonly INotificationService _notificationService;
        public GetAllNotificationHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public async Task<List<Notification>> Handle(GetAllNotificationQuery request, CancellationToken cancellationToken)
        {
            return await _notificationService.GetAllAsync();
        }
    }
}
