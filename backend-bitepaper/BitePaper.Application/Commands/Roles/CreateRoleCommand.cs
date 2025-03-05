using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using BitePaper.Models.Entities;

namespace BitePaper.Application.Commands.Roles
{
    public record CreateRoleCommand(Role Role) : IRequest;
}
