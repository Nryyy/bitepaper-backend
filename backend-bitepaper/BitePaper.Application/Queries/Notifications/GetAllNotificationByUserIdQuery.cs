using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Notifications
{
    public record GetAllNotificationByUserIdQuery(string UserId) : IRequest<List<Notification>>;
}
