using ComorgApp.Entities;
using System.Collections.Generic;

namespace ComorgApp.Models
{
    public class BroadcastViewModel
    {
        public Broadcast Broadcast { get; set; }
        public ICollection<Broadcast> Broadcasts { get; set; }
    }
}
