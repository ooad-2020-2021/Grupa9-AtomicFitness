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
    public class FitnesProgramController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FitnesProgramController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Korisnik")]
        // GET: FitnesProgram
        public async Task<IActionResult> Index()
        {
            var currentUser = _context.Korisnik.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            int id = int.Parse(currentUser.Id);
            var fitnesProgrami = await _context.FitnesProgram.ToListAsync();
            fitnesProgrami = fitnesProgrami.FindAll(x => x.KorisnikID == id);
            return View(fitnesProgrami);
        }

        [Authorize(Roles = "Korisnik")]
        // GET: FitnesProgram/Details/5
        public async Task<IActionResult> Details()
        {
            var currentUser = _context.Korisnik.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            int id = int.Parse(currentUser.Id);
            var idZadnjeg = await _context.FitnesProgram.Where(x => x.KorisnikID == id).MaxAsync(x => x.FitnesProgramID);
            var fitnesProgram = await _context.FitnesProgram.FindAsync(idZadnjeg);
            var vjezbe = await _context.Vjezba.Where(x => x.FitnesProgramID == fitnesProgram.FitnesProgramID).ToListAsync();
            return View(vjezbe);
        }

        // POST: FitnesProgram/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FitnesProgram fitnesProgram)
        {
            var currentUser = _context.Korisnik.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            int id = int.Parse(currentUser.Id);
            fitnesProgram.KorisnikID = id;
            _context.Add(fitnesProgram);
            await _context.SaveChangesAsync();
            var vjezbe = await _context.Vjezba.ToListAsync();
            var fitnesProfili = await _context.FitnesProfil.ToListAsync();
            var fitnesProfil = fitnesProfili.Find(x => x.Id == id);
            if (fitnesProfil != null)
            {
                vjezbe = vjezbe.FindAll(x => x.Level.Equals(fitnesProfil.Level) && x.Oprema.Equals(fitnesProfil.Oprema) && x.Misici.Equals(fitnesProfil.Misici));
                foreach (var vjezba in vjezbe)
                {
                    vjezba.FitnesProgramID = fitnesProgram.FitnesProgramID;
                    _context.Update(vjezba);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Korisnik")]
        // GET: FitnesProgram/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnesProgram = await _context.FitnesProgram
                .FirstOrDefaultAsync(m => m.FitnesProgramID == id);
            if (fitnesProgram == null)
            {
                return NotFound();
            }

            return View(fitnesProgram);
        }

        // POST: FitnesProgram/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed()
        {
            var currentUser = _context.Korisnik.Where(c => c.Email == User.Identity.Name).FirstOrDefault();
            int id = int.Parse(currentUser.Id);
            var fitnesProgram = await _context.FitnesProgram.Where(x => x.KorisnikID == id).FirstOrDefaultAsync();
            _context.FitnesProgram.Remove(fitnesProgram);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FitnesProgramExists(int id)
        {
            return _context.FitnesProgram.Any(e => e.FitnesProgramID == id);
        }
    }
}
