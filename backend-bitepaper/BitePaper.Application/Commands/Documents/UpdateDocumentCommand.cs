using BitePaper.Models.DTOs.Request.Document;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Commands.Documents;
public record UpdateDocumentCommand(string id, List<string> UsersWithAccessEmail) : IRequest;
