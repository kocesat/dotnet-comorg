using ComorgApp.Data;
using ComorgApp.Entities;
using ComorgApp.Interfaces;

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


    }
}
