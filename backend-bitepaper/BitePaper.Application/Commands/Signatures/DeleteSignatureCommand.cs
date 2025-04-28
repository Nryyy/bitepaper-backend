using MediatR;

namespace BitePaper.Application.Commands.Signatures;

public record DeleteSignatureCommand(string id) : IRequest;
