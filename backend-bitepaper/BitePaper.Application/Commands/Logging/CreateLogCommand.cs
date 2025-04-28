using BitePaper.Models.DTOs.Request.Logs;
using MediatR;

namespace BitePaper.Application.Commands.Logs;

public record CreateLogCommand(CreateLogRequest Request) : IRequest;
