using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitePaper.Application.Commands.Documents;
using BitePaper.Infrastructure.Interfaces.Documents;
using MediatR;

namespace BitePaper.Application.Handlers.Documents
{
    public class UpdateDocumentHandler : IRequestHandler<UpdateDocumentCommand>
    {
        private readonly IDocumentService _documentService;
        public UpdateDocumentHandler(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        public async Task Handle(UpdateDocumentCommand request, CancellationToken cancellationToken) =>
            await _documentService.UpdateAsync(request.document);
    }
}
