using BitePaper.Application.Commands.Documents;
using BitePaper.Infrastructure.Interfaces.Documents;
using BitePaper.Models.DTOs.Request.Document;
using MediatR;

namespace BitePaper.Application.Handlers.Documents;
public class UpdateDocumentHandler(IDocumentService documentService) : IRequestHandler<UpdateDocumentCommand>
{
    public async Task Handle(UpdateDocumentCommand request, CancellationToken cancellationToken) =>
        await documentService.UpdateUsersWithAccessAsync(request.id, request.UsersWithAccessEmail);

}