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
    public class AdopcjasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdopcjasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adopcjas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Adopcja.Include(a => a.IdPracownikaNavigation).Include(a => a.IdUzytkownikaNavigation).Include(a => a.IdZwierzeciaNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Adopcjas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcja = await _context.Adopcja
                .Include(a => a.IdPracownikaNavigation)
                .Include(a => a.IdUzytkownikaNavigation)
                .Include(a => a.IdZwierzeciaNavigation)
                .FirstOrDefaultAsync(m => m.IdAdopcji == id);
            if (adopcja == null)
            {
                return NotFound();
            }

            return View(adopcja);
        }
        [Authorize(Roles = "Admin")]
        // GET: Adopcjas/Create
        public IActionResult Create()
        {
            ViewData["IdPracownika"] = new SelectList(_context.Pracownik, "IdPracownika", "IdPracownika");
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "IdUzytkownika");
            ViewData["IdZwierzecia"] = new SelectList(_context.Zwierze, "IdZwierzecia", "IdZwierzecia");
            return View();
        }

        // POST: Adopcjas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdopcji,IdZwierzecia,IdUzytkownika,IdPracownika,StatusAdopcji,DataRozpoczeciaAdopcji,DataZakonczeniaAdopcji")] Adopcja adopcja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adopcja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPracownika"] = new SelectList(_context.Pracownik, "IdPracownika", "IdPracownika", adopcja.IdPracownika);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "IdUzytkownika", adopcja.IdUzytkownika);
            ViewData["IdZwierzecia"] = new SelectList(_context.Zwierze, "IdZwierzecia", "IdZwierzecia", adopcja.IdZwierzecia);
            return View(adopcja);
        }
        [Authorize(Roles = "Admin")]
        // GET: Adopcjas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcja = await _context.Adopcja.FindAsync(id);
            if (adopcja == null)
            {
                return NotFound();
            }
            ViewData["IdPracownika"] = new SelectList(_context.Pracownik, "IdPracownika", "IdPracownika", adopcja.IdPracownika);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "IdUzytkownika", adopcja.IdUzytkownika);
            ViewData["IdZwierzecia"] = new SelectList(_context.Zwierze, "IdZwierzecia", "IdZwierzecia", adopcja.IdZwierzecia);
            return View(adopcja);
        }

        // POST: Adopcjas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdopcji,IdZwierzecia,IdUzytkownika,IdPracownika,StatusAdopcji,DataRozpoczeciaAdopcji,DataZakonczeniaAdopcji")] Adopcja adopcja)
        {
            if (id != adopcja.IdAdopcji)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adopcja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdopcjaExists(adopcja.IdAdopcji))
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
            ViewData["IdPracownika"] = new SelectList(_context.Pracownik, "IdPracownika", "IdPracownika", adopcja.IdPracownika);
            ViewData["IdUzytkownika"] = new SelectList(_context.Uzytkownik, "IdUzytkownika", "IdUzytkownika", adopcja.IdUzytkownika);
            ViewData["IdZwierzecia"] = new SelectList(_context.Zwierze, "IdZwierzecia", "IdZwierzecia", adopcja.IdZwierzecia);
            return View(adopcja);
        }
        [Authorize(Roles = "Admin")]
        // GET: Adopcjas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcja = await _context.Adopcja
                .Include(a => a.IdPracownikaNavigation)
                .Include(a => a.IdUzytkownikaNavigation)
                .Include(a => a.IdZwierzeciaNavigation)
                .FirstOrDefaultAsync(m => m.IdAdopcji == id);
            if (adopcja == null)
            {
                return NotFound();
            }

            return View(adopcja);
        }

        // POST: Adopcjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adopcja = await _context.Adopcja.FindAsync(id);
            if (adopcja != null)
            {
                _context.Adopcja.Remove(adopcja);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdopcjaExists(int id)
        {
            return _context.Adopcja.Any(e => e.IdAdopcji == id);
        }
    }
}
