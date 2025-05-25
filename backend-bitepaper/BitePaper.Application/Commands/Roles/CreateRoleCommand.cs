using MediatR;
using BitePaper.Models.DTOs.Request.Role;

namespace BitePaper.Application.Commands.Roles;
public record CreateRoleCommand(CreateRoleRequest Role) : IRequest;
