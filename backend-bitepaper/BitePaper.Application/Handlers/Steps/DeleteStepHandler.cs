using BitePaper.Application.Commands.Steps;
using BitePaper.Infrastructure.Interfaces.Steps;
using MediatR;

namespace BitePaper.Application.Handlers.Steps;
    public class DeleteStepHandler : IRequestHandler<DeleteStepCommand>
{
    private readonly IStepService _stepService;
    public DeleteStepHandler(IStepService stepService)
    {
        _stepService = stepService;
    }
    public async Task Handle(DeleteStepCommand request, CancellationToken cancellationToken) =>
        await _stepService.DeleteAsync(request.Id);
}
