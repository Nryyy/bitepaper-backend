using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Commands.Steps;
    public record CreateStepCommand(Step step) : IRequest;
