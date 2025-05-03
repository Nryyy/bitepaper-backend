using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Documents;
public record GetDocumentByEmailQuery(string Id) : IRequest<List<Document?>>;
