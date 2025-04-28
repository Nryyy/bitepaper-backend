using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Documents;

public record GetDocumentByIdQuery(string id) : IRequest<Document?>;
