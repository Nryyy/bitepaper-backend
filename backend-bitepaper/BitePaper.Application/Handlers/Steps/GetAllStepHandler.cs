using BitePaper.Application.Queries.Steps;
using BitePaper.Infrastructure.Interfaces.Steps;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Steps;
    public class GetAllStepHandler : IRequestHandler<GetAllStepQuery, List<Step>>
{
    private readonly IStepService _stepRepository;
    public GetAllStepHandler(IStepService stepRepository)
    {
        _stepRepository = stepRepository;
    }
    public async Task<List<Step>> Handle(GetAllStepQuery request, CancellationToken cancellationToken)
    {
        return await _stepRepository.GetAllAsync();
    }
}
