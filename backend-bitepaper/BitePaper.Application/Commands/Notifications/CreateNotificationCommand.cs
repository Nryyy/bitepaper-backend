using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Commands.Notifications
{
    public record CreateNotificationCommand(Notification notification) : IRequest;
}
