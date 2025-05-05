using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Commands.DocumentComments;
    public record CreateDocumentCommentCommand(DocumentComment documentComment) : IRequest;
