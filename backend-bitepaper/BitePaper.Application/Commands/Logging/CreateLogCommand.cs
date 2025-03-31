using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Commands.Logs
{
    public record CreateLogCommand(Log log) : IRequest;
}
