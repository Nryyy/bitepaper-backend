using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.DocumentComments;
    public record GetAllDocumentCommentQuery : IRequest<List<DocumentComment>>;
