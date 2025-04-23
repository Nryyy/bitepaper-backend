using BitePaper.Application.Queries.Documents;
using BitePaper.Infrastructure.Interfaces.Documents;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Documents;
public class GetAllDocumentsHandler(IDocumentService documentService)
    : IRequestHandler<GetAllDocumentQuery, List<Document>>
{
    public async Task<List<Document>> Handle(GetAllDocumentQuery request, CancellationToken cancellationToken) =>
        await documentService.GetAllAsync();
}