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
    public class ProductAssociationsController : Controller
    {
        private readonly TabadolContext _context;

        public ProductAssociationsController(TabadolContext context)
        {
            _context = context;
        }

        // GET: ProductAssociations
        public async Task<IActionResult> Index()
        {
            var tabadolContext = _context.ProductAssociation.Include(p => p.Association).Include(p => p.Product);
            return View(await tabadolContext.ToListAsync());
        }

        // GET: ProductAssociations/Details/5
        public async Task<IActionResult> Details(int? ASSId,  int? ProductID)
        {
            if (ASSId == null  || ProductID == null || _context.ProductAssociation == null)
            {
                return NotFound();
            }

            var productAssociation = await _context.ProductAssociation
                .Include(p => p.Association)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ASSId == ASSId && m.ProductID == ProductID);
            if (productAssociation == null)
            {
                return NotFound();
            }

            return View(productAssociation);
        }

        // GET: ProductAssociations/Create
        public IActionResult Create()
        {
            ViewData["ASSId"] = new SelectList(_context.Associations, "ASSId", "ASSName");
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription");
            return View();
        }

        // POST: ProductAssociations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ASSId")] ProductAssociation productAssociation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productAssociation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ASSId"] = new SelectList(_context.Associations, "ASSId", "ASSName", productAssociation.ASSId);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription", productAssociation.ProductID);
            return View(productAssociation);
        }

        // GET: ProductAssociations/Edit/5
        public async Task<IActionResult> Edit(int? ASSId, int? ProductID)
        {
            if (ASSId == null || ProductID == null || _context.ProductAssociation == null)
            {
                return NotFound();
            }

            var productAssociation = await _context.ProductAssociation.FindAsync(ASSId, ProductID);
            if (productAssociation == null)
            {
                return NotFound();
            }
            ViewData["ASSId"] = new SelectList(_context.Associations, "ASSId", "ASSName", productAssociation.ASSId);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription", productAssociation.ProductID);
            return View(productAssociation);
        }

        // POST: ProductAssociations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ASSId, int ProductID, [Bind("ProductID,ASSId")] ProductAssociation productAssociation)
        {
            if (ASSId != productAssociation.ASSId || ProductID != productAssociation.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productAssociation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductAssociationExists(productAssociation.ASSId, productAssociation.ProductID))
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
            ViewData["ASSId"] = new SelectList(_context.Associations, "ASSId", "ASSName", productAssociation.ASSId);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductDescription", productAssociation.ProductID);
            return View(productAssociation);
        }

        // GET: ProductAssociations/Delete/5
        public async Task<IActionResult> Delete(int? ASSId, int? ProductID)
        {
            if (ASSId == null || ProductID == null || _context.ProductAssociation == null)
            {
                return NotFound();
            }

            var productAssociation = await _context.ProductAssociation
                .Include(p => p.Association)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ASSId == ASSId && m.ProductID == ProductID);
            if (productAssociation == null)
            {
                return NotFound();
            }

            return View(productAssociation);
        }

        // POST: ProductAssociations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ASSId, int ProductID)
        {
            if (_context.ProductAssociation == null)
            {
                return Problem("Entity set 'TabadolContext.ProductAssociation'  is null.");
            }
            var productAssociation = await _context.ProductAssociation.FindAsync(ASSId, ProductID);
            if (productAssociation != null)
            {
                _context.ProductAssociation.Remove(productAssociation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductAssociationExists(int ASSId, int ProductID)
        {
          return (_context.ProductAssociation?.Any(e => e.ASSId == ASSId && e.ProductID == ProductID)).GetValueOrDefault();
        }
    }
}
