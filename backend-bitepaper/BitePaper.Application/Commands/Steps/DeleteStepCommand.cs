using MediatR;

namespace BitePaper.Application.Commands.Steps;
    public record DeleteStepCommand(string Id) : IRequest;

