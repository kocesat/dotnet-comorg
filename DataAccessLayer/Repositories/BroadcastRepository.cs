using ComorgApp.Data;
using ComorgApp.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BroadcastRepository : Repository<Broadcast>, IBroadcastRepository
    {
        public BroadcastRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public async Task<IEnumerable<Broadcast>> GetAllPublished()
        {
            return await ApplicationDbContext.Broadcasts.Where(b => b.IsPublished == true).ToListAsync();
        }

        public ApplicationDbContext ApplicationDbContext {
            get
            {
                return Context as ApplicationDbContext;
            }
        }
    }
}
