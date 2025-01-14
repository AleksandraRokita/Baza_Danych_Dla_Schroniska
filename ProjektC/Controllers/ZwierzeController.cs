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
    public class ZwierzeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZwierzeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var applicationDbContext = _context.Zwierze
                .Include(z => z.IdLokacjiNavigation) 
                .AsQueryable(); 

            if (!string.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(z =>
                    z.IdZwierzecia.ToString().Contains(searchString) ||  
                    z.Gatunek.Contains(searchString) ||
                    z.Imie.Contains(searchString) ||
                    z.Rasa.Contains(searchString));
            }

            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Zwierze
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Zwierze.Include(z => z.IdLokacjiNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Zwierze/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zwierze = await _context.Zwierze
                .Include(z => z.IdLokacjiNavigation)
                .FirstOrDefaultAsync(m => m.IdZwierzecia == id);
            if (zwierze == null)
            {
                return NotFound();
            }

            return View(zwierze);
        }
        [Authorize(Roles = "Admin")]
        // GET: Zwierze/Create
        public IActionResult Create()
        {
            ViewData["IdLokacji"] = new SelectList(_context.Set<Lokacja>(), "IdLokacji", "IdLokacji");
            return View();
        }

        // POST: Zwierze/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZwierzecia,Gatunek,Imie,Rasa,Wiek,Waga,IdLokacji")] Zwierze zwierze)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zwierze);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLokacji"] = new SelectList(_context.Set<Lokacja>(), "IdLokacji", "IdLokacji", zwierze.IdLokacji);
            return View(zwierze);
        }

        // GET: Zwierze/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zwierze = await _context.Zwierze.FindAsync(id);
            if (zwierze == null)
            {
                return NotFound();
            }
            ViewData["IdLokacji"] = new SelectList(_context.Set<Lokacja>(), "IdLokacji", "IdLokacji", zwierze.IdLokacji);
            return View(zwierze);
        }

        // POST: Zwierze/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZwierzecia,Gatunek,Imie,Rasa,Wiek,Waga,IdLokacji")] Zwierze zwierze)
        {
            if (id != zwierze.IdZwierzecia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zwierze);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZwierzeExists(zwierze.IdZwierzecia))
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
            ViewData["IdLokacji"] = new SelectList(_context.Set<Lokacja>(), "IdLokacji", "IdLokacji", zwierze.IdLokacji);
            return View(zwierze);
        }
        [Authorize(Roles = "Admin")]
        // GET: Zwierze/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zwierze = await _context.Zwierze
                .Include(z => z.IdLokacjiNavigation)
                .FirstOrDefaultAsync(m => m.IdZwierzecia == id);
            if (zwierze == null)
            {
                return NotFound();
            }

            return View(zwierze);
        }

        // POST: Zwierze/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zwierze = await _context.Zwierze.FindAsync(id);
            if (zwierze != null)
            {
                _context.Zwierze.Remove(zwierze);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZwierzeExists(int id)
        {
            return _context.Zwierze.Any(e => e.IdZwierzecia == id);
        }
    }
}
