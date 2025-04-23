using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Roles;
public record GetRoleByIdQuery(string Id) : IRequest<Role?>;