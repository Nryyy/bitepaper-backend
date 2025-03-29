using MediatR;
using BitePaper.Models.Entities;
using System.Globalization;

namespace BitePaper.Application.Commands.Statuses
{
    public record DeleteStatusCommand (string Id) : IRequest;
}
