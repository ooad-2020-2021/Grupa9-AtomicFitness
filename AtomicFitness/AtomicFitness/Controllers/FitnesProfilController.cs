using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AtomicFitness.Data;
using AtomicFitness.Models;
using Microsoft.AspNetCore.Authorization;

namespace AtomicFitness.Controllers
{
    public class FitnesProfilController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FitnesProfilController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Korisnik")]
        // GET: FitnesProfil
        public async Task<IActionResult> Index()
        {

            return View(await _context.FitnesProfil.ToListAsync());
        }

        [Authorize(Roles = "Korisnik")]
        // GET: FitnesProfil/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnesProfil = await _context.FitnesProfil
                .FirstOrDefaultAsync(m => m.FitnesProfilID == id);
            if (fitnesProfil == null)
            {
                return NotFound();
            }

            return View(fitnesProfil);
        }

        [Authorize(Roles = "Korisnik")]
        // GET: FitnesProfil/Create
        public IActionResult Create()
        {
            var exists = _context.FitnesProfil.Any();
            if (exists)
            {
                return View("Views/FitnesProfil/CreateAccessDenied.cshtml");
            }
            else
            {
                return View();
            }
        }

        // POST: FitnesProfil/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FitnesProfilID,Spol,Level,Starost,Kilaza,Visina,Oprema,Ciljevi,Misici")] FitnesProfil fitnesProfil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fitnesProfil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fitnesProfil);
        }

        [Authorize(Roles = "Korisnik")]
        // GET: FitnesProfil/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnesProfil = await _context.FitnesProfil.FindAsync(id);
            if (fitnesProfil == null)
            {
                return NotFound();
            }
            return View(fitnesProfil);
        }

        // POST: FitnesProfil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FitnesProfilID,Spol,Level,Starost,Kilaza,Visina,Oprema,Ciljevi,Misici")] FitnesProfil fitnesProfil)
        {
            if (id != fitnesProfil.FitnesProfilID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fitnesProfil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FitnesProfilExists(fitnesProfil.FitnesProfilID))
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
            return View(fitnesProfil);
        }

        [Authorize(Roles = "Korisnik")]
        // GET: FitnesProfil/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnesProfil = await _context.FitnesProfil
                .FirstOrDefaultAsync(m => m.FitnesProfilID == id);
            if (fitnesProfil == null)
            {
                return NotFound();
            }

            return View(fitnesProfil);
        }

        // POST: FitnesProfil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fitnesProfil = await _context.FitnesProfil.FindAsync(id);
            _context.FitnesProfil.Remove(fitnesProfil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FitnesProfilExists(int id)
        {
            return _context.FitnesProfil.Any(e => e.FitnesProfilID == id);
        }
    }
}
