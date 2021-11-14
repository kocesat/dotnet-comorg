using ComorgApp.Data;
using ComorgApp.Entities;
using ComorgApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComorgApp.Repositories
{
    public class FolderRepository : Repository<Folder>, IFolderRepository
    {
        public FolderRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public ApplicationDbContext ApplicationDbContext 
        { 
            get
            {
                return base.Context as ApplicationDbContext;
            }
        }

        public async Task<IEnumerable<Folder>> GetSubFoldersAsync(int? id)
        {
            if (id == null)
            {
                return await ApplicationDbContext.Folders
                                .Where(folder => folder.ParentFolderId == null)
                                .OrderBy(f => f.Created)
                                .ToListAsync();
            }

            return await ApplicationDbContext.Folders
                            .Where(folder => folder.ParentFolderId == id)
                            .Include(f => f.ParentFolder)
                            .OrderBy(f => f.Created)
                            .ToListAsync();
        }

    }
}
