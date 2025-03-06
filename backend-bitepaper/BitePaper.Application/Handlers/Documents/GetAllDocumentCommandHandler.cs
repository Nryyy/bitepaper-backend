using BitePaper.Application.Queries.Documents;
using BitePaper.Infrastructure.Interfaces.Documents;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Documents
{
    public class GetAllDocumentCommandHandler : IRequestHandler<GetAllDocumentQuery, List<Document>>
    {
        private readonly IDocumentService _documentService;
        public GetAllDocumentCommandHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        public async Task<List<Document>> Handle(GetAllDocumentQuery request, CancellationToken cancellationToken) =>
            await _documentService.GetAllAsync();
    }
}
