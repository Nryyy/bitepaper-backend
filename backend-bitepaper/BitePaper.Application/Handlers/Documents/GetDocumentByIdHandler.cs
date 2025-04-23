using BitePaper.Application.Queries.Documents;
using BitePaper.Infrastructure.Interfaces.Documents;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Documents;
public class GetDocumentByIdHandler(IDocumentService documentService)
    : IRequestHandler<GetDocumentByIdQuery, Document?>
{
    public async Task<Document?> Handle(GetDocumentByIdQuery request, CancellationToken cancellationToken) =>
        await documentService.GetByIdAsync(request.Id);
}