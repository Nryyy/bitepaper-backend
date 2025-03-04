using BitePaper.Application.Commands.TestEnteties;
using BitePaper.Infrastructure.Interfaces.TestEntities;
using MediatR;

namespace BitePaper.Application.Handlers.TestEnteties;

public class CreateTestEntetyCommandHandler : IRequestHandler<CreateTestEntetyCommand>
{
    private readonly ITestService _testService;

    public CreateTestEntetyCommandHandler(ITestService testService)
    {
        _testService = testService;
    }

    public async Task Handle(CreateTestEntetyCommand request, CancellationToken cancellationToken)
    {
        await _testService.CreateAsync(request.TestEntity);
    }
}