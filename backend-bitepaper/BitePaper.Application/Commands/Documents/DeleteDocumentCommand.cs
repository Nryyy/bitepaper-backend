using MediatR;
using MongoDB.Bson;

namespace BitePaper.Application.Commands.Documents
{
    public record DeleteDocumentCommand(string id) : IRequest;
}
