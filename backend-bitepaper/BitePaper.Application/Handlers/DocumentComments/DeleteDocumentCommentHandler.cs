using BitePaper.Application.Commands.DocumentComments;
using BitePaper.Infrastructure.Interfaces.DocumentComments;
using MediatR;

namespace BitePaper.Application.Handlers.DocumentComments;
    public class DeleteDocumentCommentHandler : IRequestHandler<DeleteDocumentCommentCommand>
    {
    private readonly IDocumentCommentService _documentCommentService;
    public DeleteDocumentCommentHandler(IDocumentCommentService documentCommentService)
    {
        _documentCommentService = documentCommentService;
    }
    public async Task Handle(DeleteDocumentCommentCommand request, CancellationToken cancellationToken) =>
        await _documentCommentService.DeleteAsync(request.id);
}
