using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBroadcastRepository Broadcasts { get; }
        IParticipantRepository Participants { get; }
        Task<int> Complete();
    }
}
