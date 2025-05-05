using BitePaper.Application.Commands.DocumentComments;
using BitePaper.Infrastructure.Interfaces.DocumentComments;
using MediatR;

namespace BitePaper.Application.Handlers.DocumentComments;
    public class UpdateDocumentCommentHandler : IRequestHandler<UpdateDocumentCommentCommand>
    {
    private readonly IDocumentCommentService _documentCommentService;
    public UpdateDocumentCommentHandler(IDocumentCommentService documentCommentService)
    {
        _documentCommentService = documentCommentService;
    }
    public async Task Handle(UpdateDocumentCommentCommand request, CancellationToken cancellationToken) =>
        await _documentCommentService.UpdateAsync(request.documentComment);
}
