using BitePaper.Application.Commands.Notifications;
using BitePaper.Infrastructure.Interfaces.Notifications;
using MediatR;

namespace BitePaper.Application.Handlers.Notifications
{
    internal class DeleteNotificationHandler : IRequestHandler<DeleteNotificationCommand>
    {
        private readonly INotificationService _notificationService;
        public DeleteNotificationHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public async Task Handle(DeleteNotificationCommand request, CancellationToken cancellationToken) =>
            await _notificationService.DeleteAsync(request.Id);
    }
}
