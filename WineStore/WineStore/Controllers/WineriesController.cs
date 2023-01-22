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
    public class WineriesController : Controller
    {
        private readonly WineStoreContext _context;

        public WineriesController(WineStoreContext context)
        {
            _context = context;
        }

        // GET: Wineries
        public async Task<IActionResult> Index()
        {
              return View(await _context.Winery.ToListAsync());
        }

        // GET: Wineries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Winery == null)
            {
                return NotFound();
            }

            var winery = await _context.Winery
                .FirstOrDefaultAsync(m => m.Id == id);
            if (winery == null)
            {
                return NotFound();
            }

            return View(winery);
        }

        // GET: Wineries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wineries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Winery winery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(winery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(winery);
        }

        // GET: Wineries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Winery == null)
            {
                return NotFound();
            }

            var winery = await _context.Winery.FindAsync(id);
            if (winery == null)
            {
                return NotFound();
            }
            return View(winery);
        }

        // POST: Wineries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Winery winery)
        {
            if (id != winery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(winery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WineryExists(winery.Id))
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
            return View(winery);
        }

        // GET: Wineries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Winery == null)
            {
                return NotFound();
            }

            var winery = await _context.Winery
                .FirstOrDefaultAsync(m => m.Id == id);
            if (winery == null)
            {
                return NotFound();
            }

            return View(winery);
        }

        // POST: Wineries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Winery == null)
            {
                return Problem("Entity set 'WineStoreContext.Winery'  is null.");
            }
            var winery = await _context.Winery.FindAsync(id);
            if (winery != null)
            {
                _context.Winery.Remove(winery);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WineryExists(int id)
        {
          return _context.Winery.Any(e => e.Id == id);
        }
    }
}
