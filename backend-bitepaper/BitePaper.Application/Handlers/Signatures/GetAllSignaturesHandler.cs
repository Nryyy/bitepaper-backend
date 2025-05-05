using BitePaper.Application.Queries.Signatures;
using BitePaper.Infrastructure.Interfaces.Signatures;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Signatures
{
    public class GetAllSignaturesHandler : IRequestHandler<GetAllSignaturesQuery, List<Signature>>
    {
        private readonly ISignatureService _signatureService;
        public GetAllSignaturesHandler(ISignatureService signatureService)
        {
            _signatureService = signatureService;
        }
        public async Task<List<Signature>> Handle(GetAllSignaturesQuery request, CancellationToken cancellationToken) => await _signatureService.GetAllAsync();
    }
}
