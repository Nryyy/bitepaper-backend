using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Commands.Notifications
{
    public record DeleteNotificationCommand(string Id) : IRequest;
}
