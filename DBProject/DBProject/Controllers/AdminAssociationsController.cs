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
    public class AdminAssociationsController : Controller
    {
        private readonly TabadolContext _context;

        public AdminAssociationsController(TabadolContext context)
        {
            _context = context;
        }

        // GET: AdminAssociations
        public async Task<IActionResult> Index()
        {
            var tabadolContext = _context.AdminAssociation.Include(a => a.Admin).Include(a => a.Association);
            return View(await tabadolContext.ToListAsync());
        }

        // GET: AdminAssociations/Details/5
        public async Task<IActionResult> Details(int? AdminId, int? ASSId)
        {
            if (AdminId == null || ASSId == null || _context.AdminAssociation == null)
            {
                return NotFound();
            }

            var adminAssociation = await _context.AdminAssociation
                .Include(a => a.Admin)
                .Include(a => a.Association)
                .FirstOrDefaultAsync(m => m.AdminId == AdminId && m.ASSId == ASSId);
            if (adminAssociation == null)
            {
                return NotFound();
            }

            return View(adminAssociation);
        }

        // GET: AdminAssociations/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminFName");
            ViewData["ASSId"] = new SelectList(_context.Associations, "ASSId", "ASSName");
            return View();
        }

        // POST: AdminAssociations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminId,ASSId")] AdminAssociation adminAssociation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminAssociation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminFName", adminAssociation.AdminId);
            ViewData["ASSId"] = new SelectList(_context.Associations, "ASSId", "ASSName", adminAssociation.ASSId);
            return View(adminAssociation);
        }

        // GET: AdminAssociations/Edit/5
        public async Task<IActionResult> Edit(int? AdminId, int? ASSId)
        {
            if (AdminId == null || ASSId == null || _context.AdminAssociation == null)
            {
                return NotFound();
            }

            var adminAssociation = await _context.AdminAssociation.FindAsync( AdminId, ASSId);
            if (adminAssociation == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminFName", adminAssociation.AdminId);
            ViewData["ASSId"] = new SelectList(_context.Associations, "ASSId", "ASSName", adminAssociation.ASSId);
            return View(adminAssociation);
        }

        // POST: AdminAssociations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int AdminId, int ASSId, [Bind("AdminId,ASSId")] AdminAssociation adminAssociation)
        {
            if (AdminId != adminAssociation.AdminId || ASSId != adminAssociation.ASSId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminAssociation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminAssociationExists(adminAssociation.AdminId, adminAssociation.ASSId))
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
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminFName", adminAssociation.AdminId);
            ViewData["ASSId"] = new SelectList(_context.Associations, "ASSId", "ASSName", adminAssociation.ASSId);
            return View(adminAssociation);
        }

        // GET: AdminAssociations/Delete/5
        public async Task<IActionResult> Delete(int? AdminId, int? ASSId)
        {
            if (AdminId == null || ASSId == null || _context.AdminAssociation == null)
            {
                return NotFound();
            }

            var adminAssociation = await _context.AdminAssociation
                .Include(a => a.Admin)
                .Include(a => a.Association)
                .FirstOrDefaultAsync(m => m.AdminId == AdminId && m.ASSId == ASSId);
            if (adminAssociation == null)
            {
                return NotFound();
            }

            return View(adminAssociation);
        }

        // POST: AdminAssociations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int AdminId, int ASSId)
        {
            if (_context.AdminAssociation == null)
            {
                return Problem("Entity set 'TabadolContext.AdminAssociation'  is null.");
            }
            var adminAssociation = await _context.AdminAssociation.FindAsync(AdminId,ASSId);
            if (adminAssociation != null)
            {
                _context.AdminAssociation.Remove(adminAssociation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminAssociationExists(int AdminId, int ASSId)
        {
          return (_context.AdminAssociation?.Any(e => e.AdminId == AdminId && e.ASSId == ASSId)).GetValueOrDefault();
        }
    }
}
