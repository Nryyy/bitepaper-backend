using BitePaper.Application.Commands.Steps;
using BitePaper.Infrastructure.Interfaces.Steps;
using MediatR;

namespace BitePaper.Application.Handlers.Steps;
    public class CreateStepHandler : IRequestHandler<CreateStepCommand>
{
    private readonly IStepService _stepService;
    public CreateStepHandler(IStepService stepService)
    {
        _stepService = stepService;
    }
    public async Task Handle(CreateStepCommand request, CancellationToken cancellationToken) =>
        await _stepService.CreateAsync(request.step);
}
