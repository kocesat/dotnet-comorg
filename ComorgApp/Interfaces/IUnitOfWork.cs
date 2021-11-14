using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComorgApp.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBroadcastRepository Broadcasts { get; }
        IParticipantRepository Participants { get; }
        IFolderRepository Folders { get; }
        Task<int> Complete();
    }
}
