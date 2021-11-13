using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComorgApp.Data;
using ComorgApp.Entities;
using ComorgApp.Models;

namespace ComorgApp.Areas.SystemAdmin.Controllers
{
    [Area("SystemAdmin")]
    public class BroadcastsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BroadcastsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SystemAdmin/Broadcasts
        public async Task<IActionResult> Index()
        {
            var vm = new BroadcastViewModel()
            {
                Broadcast = new Broadcast(),
                Broadcasts = await _context.Broadcasts
                                    .OrderByDescending(b => b.Created)
                                    .ToListAsync()
            };

            return View(vm);
        }

        // GET: SystemAdmin/Broadcasts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var broadcast = await _context.Broadcasts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (broadcast == null)
            {
                return NotFound();
            }

            return View(broadcast);
        }

        // GET: SystemAdmin/Broadcasts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SystemAdmin/Broadcasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,Content,IsPublished")] Broadcast broadcast)
        {
            if (ModelState.IsValid)
            {
                broadcast.Created = DateTime.Now;
                broadcast.LastModified = DateTime.Now;
                _context.Add(broadcast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(broadcast);
        }

        // GET: SystemAdmin/Broadcasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var broadcast = await _context.Broadcasts.FindAsync(id);
            if (broadcast == null)
            {
                return NotFound();
            }
            return View(broadcast);
        }

        // POST: SystemAdmin/Broadcasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,Content,IsPublished")] Broadcast broadcast)
        {
            if (id != broadcast.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var broadcastInDb = _context.Broadcasts.Single(b => b.Id == broadcast.Id);
                    broadcastInDb.LastModified = DateTime.Now;
                    broadcastInDb.Subject = broadcast.Subject;
                    broadcastInDb.Content = broadcast.Content;
                    broadcastInDb.IsPublished = broadcast.IsPublished;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BroadcastExists(broadcast.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(broadcast);
        }

        // GET: SystemAdmin/Broadcasts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var broadcast = await _context.Broadcasts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (broadcast == null)
            {
                return NotFound();
            }

            return View(broadcast);
        }

        // POST: SystemAdmin/Broadcasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var broadcast = await _context.Broadcasts.FindAsync(id);
            broadcast.LastModified = DateTime.Now;
            _context.Broadcasts.Remove(broadcast);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BroadcastExists(int id)
        {
            return _context.Broadcasts.Any(e => e.Id == id);
        }
    }
}
