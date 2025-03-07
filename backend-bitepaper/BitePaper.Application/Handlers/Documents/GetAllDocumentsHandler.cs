using BitePaper.Application.Queries.Documents;
using BitePaper.Infrastructure.Interfaces.Documents;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Documents
{
    public class GetAllDocumentsHandler : IRequestHandler<GetAllDocumentQuery, List<Document>>
    {
        private readonly IDocumentService _documentService;
        public GetAllDocumentsHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        public async Task<List<Document>> Handle(GetAllDocumentQuery request, CancellationToken cancellationToken) =>
            await _documentService.GetAllAsync();
    }
}
