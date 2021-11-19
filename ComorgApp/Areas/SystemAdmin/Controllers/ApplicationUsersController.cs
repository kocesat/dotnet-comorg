using ComorgApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ComorgApp.Areas.SystemAdmin.Controllers
{
    [Area("SystemAdmin")]
    public class ApplicationUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.Include(u => u.Participant);
            return View(await users.ToListAsync());
        }

    }
}
