using BitePaper.Application.Queries.Documents;
using BitePaper.Infrastructure.Interfaces.Documents;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Documents
{
    public class GetDocumentByIdHandler : IRequestHandler<GetDocumentByIdQuery, Document?>
    {
        private readonly IDocumentService _documentService;

        public GetDocumentByIdHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<Document?> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken) =>
            await _documentService.GetByIdAsync(request.id);
    }
}
