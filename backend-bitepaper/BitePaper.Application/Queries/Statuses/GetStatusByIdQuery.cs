using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Statuses;
public record GetStatusByIdQuery (string Id) : IRequest<Status?>;