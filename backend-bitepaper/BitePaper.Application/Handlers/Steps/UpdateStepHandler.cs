using BitePaper.Application.Commands.Steps;
using BitePaper.Infrastructure.Interfaces.Steps;
using MediatR;

namespace BitePaper.Application.Handlers.Steps;
    public class UpdateStepHandler : IRequestHandler<UpdateStepCommand>
{
    private readonly IStepService _stepService;
    public UpdateStepHandler(IStepService stepService)
    {
        _stepService = stepService;
    }
    public async Task Handle(UpdateStepCommand request, CancellationToken cancellationToken) =>
        await _stepService.UpdateAsync(request.step);
}
