using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Notifications
{
    public record GetAllNotificationQuery : IRequest<List<Notification>>;
}
