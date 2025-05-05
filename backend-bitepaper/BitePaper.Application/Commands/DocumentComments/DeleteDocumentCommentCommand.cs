using MediatR;

namespace BitePaper.Application.Commands.DocumentComments;
    public record DeleteDocumentCommentCommand(string id) : IRequest;
