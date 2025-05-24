using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Documents;

public record GetByIdQuery(string Id) : IRequest<List<Document?>>;