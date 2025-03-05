using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Departments;

public record GetAllDepartmentQuery : IRequest<List<Department>>;