using ComorgApp.Data;
using ComorgApp.Entities;
using ComorgApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComorgApp.Repositories
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        public DocumentRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Document>> GetFolderDocuments(int? folderId)
        {
            if (folderId == null)
            {
                return null;
            }

            var documents = ApplicationDbContext.Documents
                                .Where(d => d.FolderId == folderId)
                                .OrderByDescending(d => d.LastUpdated)
                                .ToListAsync();
            return await documents;
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get
            {
                return base.Context as ApplicationDbContext;
            }
        }
    }
}
