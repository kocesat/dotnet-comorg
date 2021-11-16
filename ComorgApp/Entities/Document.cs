using System;
using System.ComponentModel.DataAnnotations;

namespace ComorgApp.Entities
{
    public enum VersionType
    {
        Draft = 0,
        Final = 1
    }
    public class Document
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(240)]
        public string Name { get; set; }
        public string Description { get; set; }
        public VersionType Version { get; set; }

        [StringLength(40)]
        public string VersionNumber { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int FolderId { get; set; }
        public Folder Folder { get; set; }
        public string Extension { get; set; }
    }
}
