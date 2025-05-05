using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.DocumentComments;
    public record GetDocumentCommentByIdQuery(string id) : IRequest<DocumentComment?>;
