using ComorgApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComorgApp.Interfaces
{
    public interface IBroadcastRepository : IRepository<Broadcast>
    {
        Task<IEnumerable<Broadcast>> GetAllPublished();
    }
}
