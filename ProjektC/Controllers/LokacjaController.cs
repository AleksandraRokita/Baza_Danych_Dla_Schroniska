using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektC.Data;
using ProjektC.Models;

namespace ProjektC.Controllers
{
    public class LokacjaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LokacjaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lokacja
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lokacja.ToListAsync());
        }

        // GET: Lokacja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokacja = await _context.Lokacja
                .FirstOrDefaultAsync(m => m.IdLokacji == id);
            if (lokacja == null)
            {
                return NotFound();
            }

            return View(lokacja);
        }
        [Authorize(Roles = "Admin")]
        // GET: Lokacja/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lokacja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLokacji,Lokacja1")] Lokacja lokacja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lokacja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lokacja);
        }
        [Authorize(Roles = "Admin")]

        // GET: Lokacja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokacja = await _context.Lokacja.FindAsync(id);
            if (lokacja == null)
            {
                return NotFound();
            }
            return View(lokacja);
        }

        // POST: Lokacja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLokacji,Lokacja1")] Lokacja lokacja)
        {
            if (id != lokacja.IdLokacji)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lokacja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LokacjaExists(lokacja.IdLokacji))
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
            return View(lokacja);
        }
        [Authorize(Roles = "Admin")]
        // GET: Lokacja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokacja = await _context.Lokacja
                .FirstOrDefaultAsync(m => m.IdLokacji == id);
            if (lokacja == null)
            {
                return NotFound();
            }

            return View(lokacja);
        }

        // POST: Lokacja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lokacja = await _context.Lokacja.FindAsync(id);
            if (lokacja != null)
            {
                _context.Lokacja.Remove(lokacja);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LokacjaExists(int id)
        {
            return _context.Lokacja.Any(e => e.IdLokacji == id);
        }
    }
}
