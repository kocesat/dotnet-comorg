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
    public class BroadcastsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public BroadcastsController(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }
        
        // GET: Broadcasts
        public async Task<IActionResult> Index()
        {
            return View(await unitOfWork.Broadcasts.GetAllPublished());
        }

    }
}
