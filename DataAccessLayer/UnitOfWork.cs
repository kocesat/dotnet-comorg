using ComorgApp.Data;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IBroadcastRepository Broadcasts { get; private set; }
        public IParticipantRepository Participants { get; private set; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        } 
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
