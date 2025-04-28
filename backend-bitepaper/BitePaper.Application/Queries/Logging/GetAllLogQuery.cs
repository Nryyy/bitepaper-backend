using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Logs;

public record GetAllLogQuery : IRequest<List<Log>>;
