using ComorgApp.Data;
using ComorgApp.Interfaces;
using ComorgApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComorgApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Broadcasts = new BroadcastRepository(_context);
            Participants = new ParticipantRepository(_context);
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
