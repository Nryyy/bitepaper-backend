using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Signatures;

public record GetSignatureByIdQuery(string id) : IRequest<Signature?>;
