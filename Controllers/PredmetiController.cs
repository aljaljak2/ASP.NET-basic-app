using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationStelovanjeBaze.Data;
using WebApplicationStelovanjeBaze.Models;

namespace WebApplicationStelovanjeBaze.Controllers
{
    [AllowAnonymous]
    public class PredmetiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PredmetiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Predmeti
        public async Task<IActionResult> Index()
        {
            return View(await _context.Predmet.ToListAsync());
        }

        // GET: Predmeti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmet = await _context.Predmet
                .FirstOrDefaultAsync(m => m.ID == id);
            if (predmet == null)
            {
                return NotFound();
            }

            return View(predmet);
        }

        // GET: Predmeti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Predmeti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Naziv,ECTS")] Predmet predmet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(predmet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(predmet);
        }

        // GET: Predmeti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmet = await _context.Predmet.FindAsync(id);
            if (predmet == null)
            {
                return NotFound();
            }
            return View(predmet);
        }

        // POST: Predmeti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Naziv,ECTS")] Predmet predmet)
        {
            if (id != predmet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(predmet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PredmetExists(predmet.ID))
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
            return View(predmet);
        }

        // GET: Predmeti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmet = await _context.Predmet
                .FirstOrDefaultAsync(m => m.ID == id);
            if (predmet == null)
            {
                return NotFound();
            }

            return View(predmet);
        }

        // POST: Predmeti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var predmet = await _context.Predmet.FindAsync(id);
            if (predmet != null)
            {
                _context.Predmet.Remove(predmet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PredmetExists(int id)
        {
            return _context.Predmet.Any(e => e.ID == id);
        }
    }
}
