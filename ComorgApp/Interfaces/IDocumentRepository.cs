
using ComorgApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComorgApp.Interfaces
{
    public interface IDocumentRepository : IRepository<Document>
    {
        Task<IEnumerable<Document>> GetFolderDocuments(int? folderId);
    }
}
