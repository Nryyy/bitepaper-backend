using BitePaper.Models.Entities;
using MediatR;
using MongoDB.Bson;

namespace BitePaper.Application.Queries.Documents
{
    public record GetByIdDocumentQuery(ObjectId id) : IRequest<Document?>;
}
