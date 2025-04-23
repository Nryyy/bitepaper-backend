using MediatR;

namespace BitePaper.Application.Commands.Roles;
public record DeleteRoleCommand(string Id) : IRequest;
