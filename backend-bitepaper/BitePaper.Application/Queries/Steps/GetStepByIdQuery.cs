using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Steps;
    public record GetStepByIdQuery(string id) : IRequest<Step?>;

