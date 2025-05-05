using BitePaper.Application.Queries.DocumentComments;
using BitePaper.Infrastructure.Interfaces.DocumentComments;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.DocumentComments;
    public class GetAllDocumentCommentHandler : IRequestHandler<GetAllDocumentCommentQuery, List<DocumentComment>>
    {
        private readonly IDocumentCommentService _documentCommentService;
        public GetAllDocumentCommentHandler(IDocumentCommentService documentCommentService)
        {
        _documentCommentService = documentCommentService;
        }
        public async Task<List<DocumentComment>> Handle(GetAllDocumentCommentQuery request, CancellationToken cancellationToken) => await _documentCommentService.GetAllAsync();
    
    }


