using BitePaper.Application.Commands.Documents;
using BitePaper.Infrastructure.Interfaces.Documents;
using MediatR;

namespace BitePaper.Application.Handlers.Documents;
public class DeleteDocumentHandler(IDocumentService documentService) : IRequestHandler<DeleteDocumentCommand>
{
    public async Task Handle(DeleteDocumentCommand request, CancellationToken cancellationToken) =>
        await documentService.DeleteAsync(request.id);
}