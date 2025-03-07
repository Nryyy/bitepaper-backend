using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Commands.Documents
{
    public record CreateDocumentCommand(Document document) : IRequest;
}
