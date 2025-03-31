using MediatR;

namespace BitePaper.Application.Commands.Documents
{
    public record DeleteDocumentCommand(string id) : IRequest;
}
