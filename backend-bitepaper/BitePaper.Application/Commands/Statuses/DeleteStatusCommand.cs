using MediatR;

namespace BitePaper.Application.Commands.Statuses;
public record DeleteStatusCommand (string Id) : IRequest;
