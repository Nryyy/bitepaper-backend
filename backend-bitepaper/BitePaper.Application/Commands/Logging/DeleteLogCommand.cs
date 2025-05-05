using MediatR;

namespace BitePaper.Application.Commands.Logs
{
    public record DeleteLogCommand(string id) : IRequest;

}
