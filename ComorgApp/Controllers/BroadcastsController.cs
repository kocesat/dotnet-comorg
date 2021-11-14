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
    public class BroadcastsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BroadcastsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Broadcasts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Broadcasts
                        .OrderByDescending(b => b.Created)
                        .ToListAsync());
        }

    }
}
