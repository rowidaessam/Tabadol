using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBProject.Data;
using DBProject.Models;

namespace DBProject.Controllers
{
    public class AdminCategoriesController : Controller
    {
        private readonly TabadolContext _context;

        public AdminCategoriesController(TabadolContext context)
        {
            _context = context;
        }

        // GET: AdminCategories
        public async Task<IActionResult> Index()
        {
            var tabadolContext = _context.AdminCategory.Include(a => a.Admin).Include(a => a.Category);
            return View(await tabadolContext.ToListAsync());
        }

        // GET: AdminCategories/Details/5
        public async Task<IActionResult> Details(int? CategoryID, int? AdminId)
        {
            if (CategoryID == null || AdminId == null || _context.AdminCategory == null)
            {
                return NotFound();
            }

            var adminCategory = await _context.AdminCategory
                .Include(a => a.Admin)
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.CategoryID == CategoryID && m.AdminId == AdminId);
            if (adminCategory == null)
            {
                return NotFound();
            }

            return View(adminCategory);
        }

        // GET: AdminCategories/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminFName");
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: AdminCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryID,AdminId")] AdminCategory adminCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminFName", adminCategory.AdminId);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", adminCategory.CategoryID);
            return View(adminCategory);
        }

        // GET: AdminCategories/Edit/5
        public async Task<IActionResult> Edit(int? CategoryID, int? AdminId)
        {
            if (CategoryID == null || AdminId == null || _context.AdminCategory == null)
            {
                return NotFound();
            }

            var adminCategory = await _context.AdminCategory.FindAsync(CategoryID, AdminId);
            if (adminCategory == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminFName", adminCategory.AdminId);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", adminCategory.CategoryID);
            return View(adminCategory);
        }

        // POST: AdminCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int CategoryID, int AdminId, [Bind("CategoryID,AdminId")] AdminCategory adminCategory)
        {
            if (CategoryID != adminCategory.CategoryID || AdminId != adminCategory.AdminId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminCategoryExists(adminCategory.CategoryID, adminCategory.AdminId))
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
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminFName", adminCategory.AdminId);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName", adminCategory.CategoryID);
            return View(adminCategory);
        }

        // GET: AdminCategories/Delete/5
        public async Task<IActionResult> Delete(int? CategoryID, int? AdminId)
        {
            if (CategoryID == null || AdminId == null || _context.AdminCategory == null)
            {
                return NotFound();
            }

            var adminCategory = await _context.AdminCategory
                .Include(a => a.Admin)
                .Include(a => a.Category)
                .FirstOrDefaultAsync(m => m.CategoryID == CategoryID && m.AdminId == AdminId);
            if (adminCategory == null)
            {
                return NotFound();
            }

            return View(adminCategory);
        }

        // POST: AdminCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int CategoryID, int AdminId)
        {
            if (_context.AdminCategory == null)
            {
                return Problem("Entity set 'TabadolContext.AdminCategory'  is null.");
            }
            var adminCategory = await _context.AdminCategory.FindAsync(CategoryID,AdminId);
            if (adminCategory != null)
            {
                _context.AdminCategory.Remove(adminCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminCategoryExists(int CategoryID, int AdminId)
        {
          return (_context.AdminCategory?.Any(e => e.CategoryID == CategoryID && e.AdminId == AdminId)).GetValueOrDefault();
        }

    }
}
