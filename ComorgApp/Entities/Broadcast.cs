using System;
using System.ComponentModel.DataAnnotations;

namespace ComorgApp.Entities
{
    public class Broadcast
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(240, MinimumLength = 3)]
        public string Subject { get; set; }
        
        [Required]
        [StringLength(3000, MinimumLength = 3)]
        public string Content { get; set; }

        [Display(Name = "Created At")]
        public DateTime? Created { get; set; }

        [Display(Name = "Last Modified At")]
        public DateTime? LastModified { get; set; }

        [Display(Name = "Publish Immediately")]
        public bool IsPublished { get; set; } = false;  

        // TODO : Add upload attachment functionality later
    }
}
