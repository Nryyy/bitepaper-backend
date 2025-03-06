using BitePaper.Application.Commands.Documents;
using BitePaper.Infrastructure.Interfaces.Documents;
using MediatR;

namespace BitePaper.Application.Handlers.Documents
{
    public class CreateDocumentHandler : IRequestHandler<CreateDocumentCommand>
    {
        private readonly IDocumentService _documentService;
        public CreateDocumentHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task Handle(CreateDocumentCommand request, CancellationToken cancellationToken) =>
            await _documentService.CreateAsync(request.document);
    }
}
