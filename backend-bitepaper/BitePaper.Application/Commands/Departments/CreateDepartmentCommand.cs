using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Commands.Departments;

public record CreateDepartmentCommand(Department department) : IRequest;