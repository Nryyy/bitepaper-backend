using BitePaper.Application.Queries.DocumentComments;
using BitePaper.Infrastructure.Interfaces.DocumentComments;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.DocumentComments;
    public class GetDocumentCommentByIdHandler : IRequestHandler<GetDocumentCommentByIdQuery, DocumentComment?>
{
    private readonly IDocumentCommentService _documentCommentRepository;
    public GetDocumentCommentByIdHandler(IDocumentCommentService documentCommentRepository)
    {
        _documentCommentRepository = documentCommentRepository;
    }
    public async Task<DocumentComment?> Handle(GetDocumentCommentByIdQuery request, CancellationToken cancellationToken) => await _documentCommentRepository.GetByIdAsync(request.id);
}

