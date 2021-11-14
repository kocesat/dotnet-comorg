using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ComorgApp.Data;
using ComorgApp.Entities;
using ComorgApp.Interfaces;

namespace ComorgApp.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork unitOfWork;
        public ParticipantsController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            this.unitOfWork = unitOfWork;
        }

        // GET: Participants
        public async Task<IActionResult> Index()
        {
            var participants = await unitOfWork.Participants.GetAll();
            return View(participants);
        }
    }
}
