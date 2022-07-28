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
    public class PersonalInformationsController : Controller
    {
        private readonly TabadolContext _context;

        public PersonalInformationsController(TabadolContext context)
        {
            _context = context;
        }

        // GET: PersonalInformations
        public async Task<IActionResult> Index()
        {
              return _context.PersonalInformations != null ? 
                          View(await _context.PersonalInformations.ToListAsync()) :
                          Problem("Entity set 'TabadolContext.PersonalInformations'  is null.");
        }

        // GET: PersonalInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PersonalInformations == null)
            {
                return NotFound();
            }

            var personalInformation = await _context.PersonalInformations
                .FirstOrDefaultAsync(m => m.SSN == id);
            if (personalInformation == null)
            {
                return NotFound();
            }

            return View(personalInformation);
        }

        // GET: PersonalInformations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SSN,FName,LName,City,Country,Street,Email,Phone,PostalCode")] PersonalInformation personalInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalInformation);
        }

        // GET: PersonalInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PersonalInformations == null)
            {
                return NotFound();
            }

            var personalInformation = await _context.PersonalInformations.FindAsync(id);
            if (personalInformation == null)
            {
                return NotFound();
            }
            return View(personalInformation);
        }

        // POST: PersonalInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SSN,FName,LName,City,Country,Street,Email,Phone,PostalCode")] PersonalInformation personalInformation)
        {
            if (id != personalInformation.SSN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalInformationExists(personalInformation.SSN))
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
            return View(personalInformation);
        }

        // GET: PersonalInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PersonalInformations == null)
            {
                return NotFound();
            }

            var personalInformation = await _context.PersonalInformations
                .FirstOrDefaultAsync(m => m.SSN == id);
            if (personalInformation == null)
            {
                return NotFound();
            }

            return View(personalInformation);
        }

        // POST: PersonalInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PersonalInformations == null)
            {
                return Problem("Entity set 'TabadolContext.PersonalInformations'  is null.");
            }
            var personalInformation = await _context.PersonalInformations.FindAsync(id);
            if (personalInformation != null)
            {
                _context.PersonalInformations.Remove(personalInformation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalInformationExists(int id)
        {
          return (_context.PersonalInformations?.Any(e => e.SSN == id)).GetValueOrDefault();
        }
    }
}
