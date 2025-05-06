using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Users;

public record GetUserByEmailQuery(string Email) : IRequest<User?>;