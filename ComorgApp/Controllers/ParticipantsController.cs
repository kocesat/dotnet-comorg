using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComorgApp.Data;
using ComorgApp.Entities;

namespace ComorgApp.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParticipantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Participants
        public async Task<IActionResult> Index()
        {
            var participants = _context.Participants.OrderBy(x => x.Code);
            return View(await participants.ToListAsync());
        }
    }
}
