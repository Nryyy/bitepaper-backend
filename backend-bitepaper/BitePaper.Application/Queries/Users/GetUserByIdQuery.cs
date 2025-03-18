using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Users;

public record GetUserByIdQuery(string Id) : IRequest<User?>;