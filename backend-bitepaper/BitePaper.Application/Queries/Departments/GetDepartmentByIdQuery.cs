using BitePaper.Models.Entities;
using MediatR;
using MongoDB.Bson;

namespace BitePaper.Application.Queries.Departments;

public record GetDepartmentByIdQuery(string id) : IRequest<Department?>;