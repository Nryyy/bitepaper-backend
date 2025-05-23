using BitePaper.Application.Commands.Notifications;
using BitePaper.Infrastructure.Interfaces.Notifications;
using MediatR;

namespace BitePaper.Application.Handlers.Notifications
{
    public class CreateNotificationHandler : IRequestHandler<CreateNotificationCommand>
    {
        private readonly INotificationService _notificationService;
        public CreateNotificationHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public async Task Handle(CreateNotificationCommand request, CancellationToken cancellationToken) =>
            await _notificationService.CreateAsync(request.notification);
    }
}
