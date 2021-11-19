using ComorgApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComorgApp.Interfaces
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        Task<IEnumerable<ApplicationUser>> GetUsersWithParticipants();
    }
}
