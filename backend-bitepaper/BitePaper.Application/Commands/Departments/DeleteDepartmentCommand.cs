using MediatR;
using MongoDB.Bson;

namespace BitePaper.Application.Commands.Departments;

public record DeleteDepartmentCommand(ObjectId id) : IRequest;