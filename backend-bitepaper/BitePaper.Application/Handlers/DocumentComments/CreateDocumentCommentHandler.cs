using BitePaper.Application.Commands.DocumentComments;
using BitePaper.Infrastructure.Interfaces.DocumentComments;
using MediatR;

namespace BitePaper.Application.Handlers.DocumentComments;
    public class CreateDocumentCommentHandler : IRequestHandler<CreateDocumentCommentCommand>
    {
    private readonly IDocumentCommentService _documentCommentService;
    public CreateDocumentCommentHandler(IDocumentCommentService documentCommentService)
    {
        _documentCommentService = documentCommentService;
    }
    public async Task Handle(CreateDocumentCommentCommand request, CancellationToken cancellationToken) =>
        await _documentCommentService.CreateAsync(request.documentComment);
}
