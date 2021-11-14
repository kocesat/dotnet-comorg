using ComorgApp.Data;
using ComorgApp.Entities;
using ComorgApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComorgApp.Repositories
{
    public class BroadcastRepository : Repository<Broadcast>, IBroadcastRepository
    {
        public BroadcastRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public async Task<IEnumerable<Broadcast>> GetAllPublished()
        {
            return await ApplicationDbContext.Broadcasts
                .Where(b => b.IsPublished == true)
                .OrderByDescending(b => b.LastModified)
                .ToListAsync();
        }

        public ApplicationDbContext ApplicationDbContext {
            get
            {
                return base.Context as ApplicationDbContext;
            }
        }
    }
}
