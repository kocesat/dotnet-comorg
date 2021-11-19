using ComorgApp.Data;
using ComorgApp.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ComorgApp.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager; 
        }

        public Task AddAsync(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<ApplicationUser> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> FindAsync(Expression<Func<ApplicationUser, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersWithParticipants()
        {
            var users = _userManager.Users.Include(u => u.Participant);
            return await users.ToListAsync();
        }

        public void Remove(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<ApplicationUser> entities)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> SingleOrDefaultAsync(Expression<Func<ApplicationUser, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
