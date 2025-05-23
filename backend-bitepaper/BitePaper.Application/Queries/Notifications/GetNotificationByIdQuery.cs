using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Notifications
{
    public record GetNotificationByIdQuery(string Id) : IRequest<Notification>;
}
