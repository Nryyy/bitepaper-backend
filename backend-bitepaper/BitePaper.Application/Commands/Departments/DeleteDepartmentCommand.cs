using MediatR;
using MongoDB.Bson;

namespace BitePaper.Application.Commands.Departments;

public record DeleteDepartmentCommand(string id) : IRequest;