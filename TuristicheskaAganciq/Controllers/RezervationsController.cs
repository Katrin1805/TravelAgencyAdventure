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
    public class RezervationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezervationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rezervations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rezurations.Include(r => r.Clients).Include(r => r.Excursions);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rezervations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervation = await _context.Rezurations
                .Include(r => r.Clients)
                .Include(r => r.Excursions)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezervation == null)
            {
                return NotFound();
            }

            return View(rezervation);
        }

        // GET: Rezervations/Create
        public IActionResult Create()
        {
            ViewData["ClientsId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ExcursionsId"] = new SelectList(_context.Excursions, "Id", "Id");
            return View();
        }

        // POST: Rezervations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientsId,ExcursionsId,Pasangers,RegisterDate")] Rezervation rezervation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezervation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientsId"] = new SelectList(_context.Users, "Id", "Id", rezervation.ClientsId);
            ViewData["ExcursionsId"] = new SelectList(_context.Excursions, "Id", "Id", rezervation.ExcursionsId);
            return View(rezervation);
        }

        // GET: Rezervations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervation = await _context.Rezurations.FindAsync(id);
            if (rezervation == null)
            {
                return NotFound();
            }
            ViewData["ClientsId"] = new SelectList(_context.Users, "Id", "Id", rezervation.ClientsId);
            ViewData["ExcursionsId"] = new SelectList(_context.Excursions, "Id", "Id", rezervation.ExcursionsId);
            return View(rezervation);
        }

        // POST: Rezervations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientsId,ExcursionsId,Pasangers,RegisterDate")] Rezervation rezervation)
        {
            if (id != rezervation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervationExists(rezervation.Id))
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
            ViewData["ClientsId"] = new SelectList(_context.Users, "Id", "Id", rezervation.ClientsId);
            ViewData["ExcursionsId"] = new SelectList(_context.Excursions, "Id", "Id", rezervation.ExcursionsId);
            return View(rezervation);
        }

        // GET: Rezervations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervation = await _context.Rezurations
                .Include(r => r.Clients)
                .Include(r => r.Excursions)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezervation == null)
            {
                return NotFound();
            }

            return View(rezervation);
        }

        // POST: Rezervations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervation = await _context.Rezurations.FindAsync(id);
            if (rezervation != null)
            {
                _context.Rezurations.Remove(rezervation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervationExists(int id)
        {
            return _context.Rezurations.Any(e => e.Id == id);
        }
    }
}
