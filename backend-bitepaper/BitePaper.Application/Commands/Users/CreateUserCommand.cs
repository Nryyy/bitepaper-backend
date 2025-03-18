using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Commands.Users;

public record CreateUserCommand(User User) : IRequest;