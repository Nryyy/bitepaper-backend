using BitePaper.Application.Queries.Notifications;
using BitePaper.Infrastructure.Interfaces.Documents;
using BitePaper.Infrastructure.Interfaces.Notifications;
using BitePaper.Infrastructure.Services;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Notifications
{
    public class GetNotificationByIdHandler : IRequestHandler<GetNotificationByIdQuery, Notification?>
    {
        private readonly INotificationService _notificationService;
        public GetNotificationByIdHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public async Task<Notification?> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
        {
            return await _notificationService.GetByIdAsync(request.Id);
        }
    }
}
