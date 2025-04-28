using BitePaper.Models.DTOs.Request.Signatures;
using MediatR;

namespace BitePaper.Application.Commands.Signatures;

public record CreateSignatureCommand(CreateSignatureRequest Request) : IRequest;
