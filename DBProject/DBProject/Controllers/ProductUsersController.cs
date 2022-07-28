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
    public class ProductUsersController : Controller
    {
        private readonly TabadolContext _context;

        public ProductUsersController(TabadolContext context)
        {
            _context = context;
        }

        // GET: ProductUsers
        public async Task<IActionResult> Index()
        {
            var tabadolContext = _context.ProductUser.Include(p => p.Product).Include(p => p.User);
            return View(await tabadolContext.ToListAsync());
        }

        // GET: ProductUsers/Details/5
        public async Task<IActionResult> Details(int? ProductID, int? UserId)
        {
            if (ProductID == null || UserId == null|| _context.ProductUser == null)
            {
                return NotFound();
            }

            var productUser = await _context.ProductUser
                .Include(p => p.Product)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProductID == ProductID && m.UserId == UserId);
            if (productUser == null)
            {
                return NotFound();
            }

            return View(productUser);
        }

        // GET: ProductUsers/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: ProductUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,ProductID")] ProductUser productUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription", productUser.ProductID);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", productUser.UserId);
            return View(productUser);
        }

        // GET: ProductUsers/Edit/5
        public async Task<IActionResult> Edit(int? ProductID, int? UserId)
        {
            if (ProductID == null || UserId == null || _context.ProductUser == null)
            {
                return NotFound();
            }

            var productUser = await _context.ProductUser.FindAsync(ProductID, UserId);
            if (productUser == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription", productUser.ProductID);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", productUser.UserId);
            return View(productUser);
        }

        // POST: ProductUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ProductID, int UserId, [Bind("UserId,ProductID")] ProductUser productUser)
        {
            if (ProductID != productUser.ProductID || UserId != productUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductUserExists(productUser.ProductID, productUser.UserId))
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
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription", productUser.ProductID);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", productUser.UserId);
            return View(productUser);
        }

        // GET: ProductUsers/Delete/5
        public async Task<IActionResult> Delete(int? ProductID, int? UserId)
        {
            if (ProductID == null || UserId == null || _context.ProductUser == null)
            {
                return NotFound();
            }

            var productUser = await _context.ProductUser
                .Include(p => p.Product)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProductID == ProductID && m.UserId == UserId);
            if (productUser == null)
            {
                return NotFound();
            }

            return View(productUser);
        }

        // POST: ProductUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ProductID, int UserId)
        {
            if (_context.ProductUser == null)
            {
                return Problem("Entity set 'TabadolContext.ProductUser'  is null.");
            }
            var productUser = await _context.ProductUser.FindAsync(ProductID, UserId);
            if (productUser != null)
            {
                _context.ProductUser.Remove(productUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductUserExists(int ProductID, int UserId)
        {
          return (_context.ProductUser?.Any(e => e.ProductID == ProductID && e.UserId == UserId)).GetValueOrDefault();
        }
    }
}
