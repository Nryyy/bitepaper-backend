using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Steps;
    public record GetAllStepQuery : IRequest<List<Step>>;
