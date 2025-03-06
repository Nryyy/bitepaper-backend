using BitePaper.Application.Commands.Documents;
using BitePaper.Infrastructure.Interfaces.Documents;
using MediatR;

namespace BitePaper.Application.Handlers.Documents
{
    public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand>
    {
        private readonly IDocumentService _documentService;
        public DeleteDocumentCommandHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        public async Task Handle(DeleteDocumentCommand request, CancellationToken cancellationToken) =>
            await _documentService.DeleteAsync(request.id);
    }
}
