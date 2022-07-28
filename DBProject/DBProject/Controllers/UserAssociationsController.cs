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
    public class UserAssociationsController : Controller
    {
        private readonly TabadolContext _context;

        public UserAssociationsController(TabadolContext context)
        {
            _context = context;
        }

        // GET: UserAssociations
        public async Task<IActionResult> Index()
        {
            var tabadolContext = _context.UserAssociation.Include(u => u.Association).Include(u => u.User);
            return View(await tabadolContext.ToListAsync());
        }

        // GET: UserAssociations/Details/5
        public async Task<IActionResult> Details(int? UserId, int? ASSId)
        {
            if (UserId == null || ASSId == null || _context.UserAssociation == null)
            {
                return NotFound();
            }

            var userAssociation = await _context.UserAssociation
                .Include(u => u.Association)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == UserId && m.ASSId == ASSId);
            if (userAssociation == null)
            {
                return NotFound();
            }

            return View(userAssociation);
        }

        // GET: UserAssociations/Create
        public IActionResult Create()
        {
            ViewData["ASSId"] = new SelectList(_context.Associations, "ASSId", "ASSName");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: UserAssociations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ASSId,UserId")] UserAssociation userAssociation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAssociation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ASSId"] = new SelectList(_context.Associations, "ASSId", "ASSName", userAssociation.ASSId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", userAssociation.UserId);
            return View(userAssociation);
        }

        // GET: UserAssociations/Edit/5
        public async Task<IActionResult> Edit(int? UserId, int? ASSId)
        {
            if (UserId == null || ASSId == null || _context.UserAssociation == null)
            {
                return NotFound();
            }

            var userAssociation = await _context.UserAssociation.FindAsync(UserId, ASSId);
            if (userAssociation == null)
            {
                return NotFound();
            }
            ViewData["ASSId"] = new SelectList(_context.Associations, "ASSId", "ASSName", userAssociation.ASSId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", userAssociation.UserId);
            return View(userAssociation);
        }

        // POST: UserAssociations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int UserId, int ASSId, [Bind("ASSId,UserId")] UserAssociation userAssociation)
        {
            if (UserId != userAssociation.UserId || ASSId != userAssociation.ASSId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAssociation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAssociationExists(userAssociation.UserId, userAssociation.ASSId))
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
            ViewData["ASSId"] = new SelectList(_context.Associations, "ASSId", "ASSName", userAssociation.ASSId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", userAssociation.UserId);
            return View(userAssociation);
        }

        // GET: UserAssociations/Delete/5
        public async Task<IActionResult> Delete(int? UserId, int? ASSId)
        {
            if (UserId == null || ASSId == null || _context.UserAssociation == null)
            {
                return NotFound();
            }

            var userAssociation = await _context.UserAssociation
                .Include(u => u.Association)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == UserId && m.ASSId == ASSId);
            if (userAssociation == null)
            {
                return NotFound();
            }

            return View(userAssociation);
        }

        // POST: UserAssociations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int UserId, int ASSId)
        {
            if (_context.UserAssociation == null)
            {
                return Problem("Entity set 'TabadolContext.UserAssociation'  is null.");
            }
            var userAssociation = await _context.UserAssociation.FindAsync(UserId,ASSId);
            if (userAssociation != null)
            {
                _context.UserAssociation.Remove(userAssociation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAssociationExists(int UserId, int ASSId)
        {
          return (_context.UserAssociation?.Any(e => e.UserId == UserId && e.ASSId == ASSId)).GetValueOrDefault();
        }
    }
}
