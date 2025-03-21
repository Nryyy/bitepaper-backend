using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Users;

public record GetAllUsersQuery() : IRequest<IEnumerable<User>>;