using BitePaper.Application.Queries.Signatures;
using BitePaper.Infrastructure.Interfaces.Signatures;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Signatures;

public class GetSignatureById : IRequestHandler<GetSignatureByIdQuery, Signature?>
{
    private readonly ISignatureService _signatureService;
    public GetSignatureById(ISignatureService signatureService)
    {
        _signatureService = signatureService;
    }
    public async Task<Signature?> Handle(GetSignatureByIdQuery request, CancellationToken cancellationToken) => await _signatureService.GetByIdAsync(request.id);
}
