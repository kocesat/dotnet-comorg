using ComorgApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComorgApp.Interfaces
{
    public interface IFolderRepository : IRepository<Folder>
    {
        Task<IEnumerable<Folder>> GetSubFoldersAndDocumentsAsync(int? id);
        Task<Folder> GetWithDocumentsAsync(int? id);
    }
}
