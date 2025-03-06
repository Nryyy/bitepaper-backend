using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitePaper.Models.Entities;
using MongoDB.Bson;

namespace BitePaper.Infrastructure.Interfaces.Documents
{
    public interface IDocumentService
    {
        Task<List<Document>> GetAllAsync();
        Task<Document?> GetByIdAsync(ObjectId id);
        Task CreateAsync(Document document);
        Task UpdateAsync(Document document);
        Task DeleteAsync(ObjectId id);
    }
}
