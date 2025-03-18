using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Commands.Users;

public record UpdateUserCommand(User User) : IRequest;