using MediatR;

namespace BitePaper.Application.Commands.Users;

public record DeleteUserCommand(string Id) : IRequest;