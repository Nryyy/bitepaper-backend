using BitePaper.Application.Commands.Signatures;
using BitePaper.Infrastructure.Interfaces.Signatures;
using MediatR;

namespace BitePaper.Application.Handlers.Signatures
{
    public class DeleteSignatureHandler : IRequestHandler<DeleteSignatureCommand>
    {
        private readonly ISignatureService _signatureService;
        public DeleteSignatureHandler(ISignatureService signatureService)
        {
            _signatureService = signatureService;
        }
        public async Task Handle(DeleteSignatureCommand request, CancellationToken cancellationToken) => await _signatureService.DeleteAsync(request.id);
    }
}
