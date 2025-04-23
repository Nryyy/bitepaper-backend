using BitePaper.Application.Commands.Documents;
using BitePaper.Infrastructure.Interfaces.Documents;
using MediatR;

namespace BitePaper.Application.Handlers.Documents;
public class CreateDocumentHandler(IDocumentService documentService) : IRequestHandler<CreateDocumentCommand>
{
    public async Task Handle(CreateDocumentCommand request, CancellationToken cancellationToken) =>
        await documentService.CreateAsync(request.document);
}