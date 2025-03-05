using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Commands.Departments;

public record UpdateDepartmentCommand(Department department) : IRequest;