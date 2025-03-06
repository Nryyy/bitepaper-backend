using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Commands.Documents
{
    public record CreateDocumentCommand(Document document) : IRequest;
}
