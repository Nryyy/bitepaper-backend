using MediatR;
using BitePaper.Models.Entities;

namespace BitePaper.Application.Commands.TestEnteties;

public record CreateTestEntetyCommand(TestEntity TestEntity) : IRequest;