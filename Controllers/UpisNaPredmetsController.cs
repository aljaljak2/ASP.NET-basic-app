using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationStelovanjeBaze.Data;
using WebApplicationStelovanjeBaze.Models;

namespace WebApplicationStelovanjeBaze.Controllers
{
    public class UpisNaPredmetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UpisNaPredmetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UpisNaPredmets
        public async Task<IActionResult> Index()
        {
            return View(await _context.UpisNaPredmet.ToListAsync());
        }

        // GET: UpisNaPredmets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upisNaPredmet = await _context.UpisNaPredmet
                .FirstOrDefaultAsync(m => m.ID == id);
            if (upisNaPredmet == null)
            {
                return NotFound();
            }

            return View(upisNaPredmet);
        }

        // GET: UpisNaPredmets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UpisNaPredmets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,StudentId,PredmetId")] UpisNaPredmet upisNaPredmet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(upisNaPredmet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(upisNaPredmet);
        }

        // GET: UpisNaPredmets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upisNaPredmet = await _context.UpisNaPredmet.FindAsync(id);
            if (upisNaPredmet == null)
            {
                return NotFound();
            }
            return View(upisNaPredmet);
        }

        // POST: UpisNaPredmets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,StudentId,PredmetId")] UpisNaPredmet upisNaPredmet)
        {
            if (id != upisNaPredmet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(upisNaPredmet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UpisNaPredmetExists(upisNaPredmet.ID))
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
            return View(upisNaPredmet);
        }

        // GET: UpisNaPredmets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var upisNaPredmet = await _context.UpisNaPredmet
                .FirstOrDefaultAsync(m => m.ID == id);
            if (upisNaPredmet == null)
            {
                return NotFound();
            }

            return View(upisNaPredmet);
        }

        // POST: UpisNaPredmets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var upisNaPredmet = await _context.UpisNaPredmet.FindAsync(id);
            if (upisNaPredmet != null)
            {
                _context.UpisNaPredmet.Remove(upisNaPredmet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UpisNaPredmetExists(int id)
        {
            return _context.UpisNaPredmet.Any(e => e.ID == id);
        }
    }
}
