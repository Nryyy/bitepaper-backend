using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Signatures;

public record GetAllSignaturesQuery : IRequest<List<Signature>>;
