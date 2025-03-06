using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitePaper.Models.Entities;
using MediatR;

namespace BitePaper.Application.Queries.Documents
{
    public record GetAllDocumentQuery : IRequest<List<Document>>;
}
