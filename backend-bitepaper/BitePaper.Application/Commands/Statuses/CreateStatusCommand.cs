using MediatR;
using BitePaper.Models.Entities;

namespace BitePaper.Application.Commands.Statuses;
public record CreateStatusCommand (Status Status) : IRequest;