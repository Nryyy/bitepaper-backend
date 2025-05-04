using BitePaper.Application.Queries.Steps;
using BitePaper.Infrastructure.Interfaces.Steps;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Handlers.Steps;
    public class GetStepByIdHandler : IRequestHandler<GetStepByIdQuery, Step?>
{
    private readonly IStepService _stepRepository;
    public GetStepByIdHandler(IStepService stepRepository)
    {
        _stepRepository = stepRepository;
    }
    public async Task<Step?> Handle(GetStepByIdQuery request, CancellationToken cancellationToken)
    {
        return await _stepRepository.GetByIdAsync(request.id);
    }
}
