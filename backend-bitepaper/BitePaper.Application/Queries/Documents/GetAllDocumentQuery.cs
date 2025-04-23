using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Documents;
public record GetAllDocumentQuery : IRequest<List<Document>>;
