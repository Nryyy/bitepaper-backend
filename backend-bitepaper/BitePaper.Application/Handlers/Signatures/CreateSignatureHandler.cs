using BitePaper.Application.Commands.Signatures;
using BitePaper.Infrastructure.Interfaces.Signatures;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Signatures
{
    public class CreateSignatureHandler : IRequestHandler<CreateSignatureCommand>
    {
        private readonly ISignatureService _signatureService;

        public CreateSignatureHandler(ISignatureService signatureService)
        {
            _signatureService = signatureService;
        }

        public async Task Handle(CreateSignatureCommand request, CancellationToken cancellationToken)
        {
            var signature = new Signature
            {
                DocumentId = request.Request.DocumentId,
                UserId = request.Request.UserId,
                SignatureData = request.Request.SignatureData
            };

            await _signatureService.CreateAsync(signature);
        }
    }
}
