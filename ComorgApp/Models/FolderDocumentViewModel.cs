using ComorgApp.Entities;
using System.Collections.Generic;

namespace ComorgApp.Models
{
    public class FolderDocumentViewModel
    {
        public IEnumerable<Folder> Folders { get; set; }
        public IEnumerable<Document> Documents { get; set; }
    }
}
