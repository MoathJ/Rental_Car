using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Renteal_Car.Data;
using Renteal_Car.Models;

namespace Renteal_Car.Controllers
{
    public class CustamersController : Controller
    {
        private readonly RentalCarContext _context;

        public CustamersController(RentalCarContext context)
        {
            _context = context;
        }

        // GET: Custamers
        public async Task<IActionResult> Index()
        {
              return _context.Custamers != null ? 
                          View(await _context.Custamers.ToListAsync()) :
                          Problem("Entity set 'RentalCarContext.Custamers'  is null.");
        }

        // GET: 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Custamers == null)
            {
                return NotFound();
            }

            var custamer = await _context.Custamers
                .FirstOrDefaultAsync(m => m.CustmerId == id);
            if (custamer == null)
            {
                return NotFound();
            }

            return View(custamer);
        }

        
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustmerId,CustmerName,ContactInfo")] Custamer custamer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(custamer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(custamer);
        }

        // GET: Custamers/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Custamers == null)
            {
                return NotFound();
            }

            var custamer = await _context.Custamers.FindAsync(id);
            if (custamer == null)
            {
                return NotFound();
            }
            return View(custamer);
        }

        // POST: Custamers/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustmerId,CustmerName,ContactInfo")] Custamer custamer)
        {
            if (id != custamer.CustmerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(custamer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustamerExists(custamer.CustmerId))
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
            return View(custamer);
        }

        // GET: Custamers/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Custamers == null)
            {
                return NotFound();
            }

            var custamer = await _context.Custamers
                .FirstOrDefaultAsync(m => m.CustmerId == id);
            if (custamer == null)
            {
                return NotFound();
            }

            return View(custamer);
        }

        // POST: Custamers/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Custamers == null)
            {
                return Problem("Entity set 'RentalCarContext.Custamers'  is null.");
            }
            var custamer = await _context.Custamers.FindAsync(id);
            if (custamer != null)
            {
                _context.Custamers.Remove(custamer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustamerExists(int id)
        {
          return (_context.Custamers?.Any(e => e.CustmerId == id)).GetValueOrDefault();
        }
    }
}
