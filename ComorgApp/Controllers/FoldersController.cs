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
using ComorgApp.Models;

namespace ComorgApp.Controllers
{
    public class FoldersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public FoldersController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Folders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Folders.Include(f => f.ParentFolder);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Folders/Subfolders
        // Giving a folder id, it returns its subfolders and containing documents
        public async Task<IActionResult> SubFoldersAndDocuments(int? id)
        {
            IEnumerable<Document> documents = null;
            if (id != null)
            {
                var folder = await _unitOfWork.Folders.GetWithDocumentsAsync(id);
                if (folder != null)
                {
                    documents = folder.Documents;
                }
            }
            var subfolders = await _unitOfWork.Folders.GetSubFoldersAndDocumentsAsync(id);

            var vm = new FolderDocumentViewModel()
            {
                Folders = subfolders,
                Documents = documents
            };
            return View(vm);
        }

        // GET: Folders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var folder = await _context.Folders
                .Include(f => f.ParentFolder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (folder == null)
            {
                return NotFound();
            }

            return View(folder);
        }

    }
}
