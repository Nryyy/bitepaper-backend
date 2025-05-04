using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Commands.DocumentComments;
    public record UpdateDocumentCommentCommand(DocumentComment documentComment)  : IRequest;

