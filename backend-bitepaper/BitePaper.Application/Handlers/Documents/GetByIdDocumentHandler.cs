using BitePaper.Application.Queries.Documents;
using BitePaper.Infrastructure.Interfaces.Documents;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Documents
{
    public class GetByIdDocumentHandler : IRequestHandler<GetByIdDocumentQuery, Document?>
    {
        private readonly IDocumentService _documentService;

        public GetByIdDocumentHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public async Task<Document?> Handle(GetByIdDocumentQuery request, CancellationToken cancellationToken) =>
            await _documentService.GetByIdAsync(request.id);
    }
}
