using System;
using System.ComponentModel.DataAnnotations;

namespace ComorgApp.Entities
{
    public class Folder
    {
        public int Id { get; set; }

        [StringLength(140, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastModified { get; set; }
        public int? ParentFolderId { get; set; }
        public Folder ParentFolder { get; set; }
    }
}
