using BitePaper.Models.Entities;
using MediatR;
using MongoDB.Bson;

namespace BitePaper.Application.Queries.Documents
{
    public record GetDocumentByIdQuery(string id) : IRequest<Document?>;
}
