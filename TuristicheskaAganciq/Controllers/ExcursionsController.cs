using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuristicheskaAganciq.Data;

namespace TuristicheskaAganciq.Controllers
{
    public class ExcursionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExcursionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Excursions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Excursions.Include(e => e.Destinations);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Excursions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excursion = await _context.Excursions
                .Include(e => e.Destinations)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (excursion == null)
            {
                return NotFound();
            }

            return View(excursion);
        }

        // GET: Excursions/Create
        public IActionResult Create()
        {
            ViewData["DestinationsId"] = new SelectList(_context.Destinations, "Id", "Name");
            return View();
        }

        // POST: Excursions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExcursionNumber,DestinationsId,Duration,Description,VidTransport,Price,DateRegister")] Excursion excursion)
        {
            if (ModelState.IsValid)
            {
                excursion.DateRegister = DateTime.Now;
                _context.Excursions.Add(excursion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinationsId"] = new SelectList(_context.Destinations, "Id", "Name", excursion.DestinationsId);
            return View(excursion);
        }

        // GET: Excursions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excursion = await _context.Excursions.FindAsync(id);
            if (excursion == null)
            {
                return NotFound();
            }
            ViewData["DestinationsId"] = new SelectList(_context.Destinations, "Id", "Name", excursion.DestinationsId);
            return View(excursion);
        }

        // POST: Excursions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExcursionNumber,DestinationsId,Duration,Description,VidTransport,Price,DateRegister")] Excursion excursion)
        {
            if (id != excursion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    excursion.DateRegister = DateTime.Now;
                    _context.Excursions.Update(excursion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExcursionExists(excursion.Id))
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
            ViewData["DestinationsId"] = new SelectList(_context.Destinations, "Id", "Id", excursion.DestinationsId);
            return View(excursion);
        }

        // GET: Excursions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excursion = await _context.Excursions
                .Include(e => e.Destinations)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (excursion == null)
            {
                return NotFound();
            }

            return View(excursion);
        }

        // POST: Excursions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var excursion = await _context.Excursions.FindAsync(id);
            if (excursion != null)
            {
                _context.Excursions.Remove(excursion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExcursionExists(int id)
        {
            return _context.Excursions.Any(e => e.Id == id);
        }
    }
}
