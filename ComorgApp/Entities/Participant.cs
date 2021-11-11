using ComorgApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComorgApp.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(4, MinimumLength = 4)]
        public string Code { get; set; }
        
        [Required]
        [StringLength(240, MinimumLength = 2)]
        public string Name { get; set; }

        public string CodeAndName { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }

        public Participant()
        {
            CodeAndName = $"{Code} - {Name}";
        }
    }
}
