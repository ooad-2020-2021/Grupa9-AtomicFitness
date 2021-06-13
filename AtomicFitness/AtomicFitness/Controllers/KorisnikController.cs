using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtomicFitness.Data;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;

namespace AtomicFitness.Controllers
{
    public class KorisnikController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KorisnikController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrator")]
        // GET: Korisnik
        public async Task<IActionResult> Index(string SearchBy, string Search)
        {
            if (SearchBy == "Ime")
            {
                return View(await _context.Korisnik.Where(user => Search == null || user.Ime.Replace(" ", "").Equals(Regex.Replace(Search, @"\s", ""), StringComparison.InvariantCultureIgnoreCase)).ToListAsync());
            }
            else if (SearchBy == "Prezime") 
            {
                return View(await _context.Korisnik.Where(user => Search == null || user.Prezime.Replace(" ", "").Equals(Regex.Replace(Search, @"\s", ""), StringComparison.InvariantCultureIgnoreCase)).ToListAsync());
            }
            else if (SearchBy == "Email")
            {
                return View(await _context.Korisnik.Where(user => Search == null || user.Email.Equals(Regex.Replace(Search, @"\s", ""), StringComparison.InvariantCultureIgnoreCase)).ToListAsync());
            }
            else
            {
                return View(await _context.Korisnik.ToListAsync());
            }
        }

        [Authorize(Roles = "Administrator")]
        // GET: Korisnik/Details/
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Korisnik
                .FirstOrDefaultAsync(user => user.Id == id);
            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Korisnik/Delete/
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Korisnik
                .FirstOrDefaultAsync(user => user.Id == id);
            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        // POST: Korisnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var korisnik = await _context.Korisnik.FindAsync(id);
            _context.Korisnik.Remove(korisnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KorisnikExists(string id)
        {
            return _context.Korisnik.Any(user => user.Id == id);
        }
    }
}
