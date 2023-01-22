using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WineStore.Data;
using WineStore.Models;

namespace WineStore.Controllers
{
    public class VintagesController : Controller
    {
        private readonly WineStoreContext _context;

        public VintagesController(WineStoreContext context)
        {
            _context = context;
        }

        // GET: Vintages
        public async Task<IActionResult> Index()
        {
              return View(await _context.Vintage.ToListAsync());
        }

        // GET: Vintages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vintage == null)
            {
                return NotFound();
            }

            var vintage = await _context.Vintage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vintage == null)
            {
                return NotFound();
            }

            return View(vintage);
        }

        // GET: Vintages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vintages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ProductionDate")] Vintage vintage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vintage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vintage);
        }

        // GET: Vintages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vintage == null)
            {
                return NotFound();
            }

            var vintage = await _context.Vintage.FindAsync(id);
            if (vintage == null)
            {
                return NotFound();
            }
            return View(vintage);
        }

        // POST: Vintages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProductionDate")] Vintage vintage)
        {
            if (id != vintage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vintage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VintageExists(vintage.Id))
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
            return View(vintage);
        }

        // GET: Vintages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vintage == null)
            {
                return NotFound();
            }

            var vintage = await _context.Vintage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vintage == null)
            {
                return NotFound();
            }

            return View(vintage);
        }

        // POST: Vintages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vintage == null)
            {
                return Problem("Entity set 'WineStoreContext.Vintage'  is null.");
            }
            var vintage = await _context.Vintage.FindAsync(id);
            if (vintage != null)
            {
                _context.Vintage.Remove(vintage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VintageExists(int id)
        {
          return _context.Vintage.Any(e => e.Id == id);
        }
    }
}
