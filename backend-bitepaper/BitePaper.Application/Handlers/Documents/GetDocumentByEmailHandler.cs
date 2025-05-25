using BitePaper.Application.Queries.Documents;
using BitePaper.Infrastructure.Interfaces.Documents;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Documents;
public class GetDocumentByEmailHandler(IDocumentService documentService)
    : IRequestHandler<GetDocumentByEmailQuery, List<Document?>>
{
    public async Task<List<Document?>> Handle(GetDocumentByEmailQuery request, CancellationToken cancellationToken) =>
        await documentService.GetByEmailAsync(request.Id);
}