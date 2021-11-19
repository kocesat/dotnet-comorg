using ComorgApp.Data;
using ComorgApp.Interfaces;
using ComorgApp.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace ComorgApp.Services
{
    public class UserService
    {
        public ApplicationUserRepository Users { get; private set; }
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            Users = new ApplicationUserRepository(_userManager);   
        }

        public async Task<string> GetAllUserAsync()
        {
            var users = await Users.GetUsersWithParticipants();
            return JsonSerializer.Serialize(users);
        }
    }
}
