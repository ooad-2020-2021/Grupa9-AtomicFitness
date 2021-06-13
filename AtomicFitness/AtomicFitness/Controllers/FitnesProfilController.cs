using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        private Korisnik getCurrent()
        {
            return _context.Korisnik.Where(user => user.Email == User.Identity.Name).FirstOrDefault();
        }

        private int getId(string userId)
        {
            return int.Parse(userId);
        }

        [Authorize(Roles = "Korisnik")]
        // GET: FitnesProfil
        public async Task<IActionResult> Index()
        {
            var fitnesProfili = await _context.FitnesProfil.ToListAsync();
            var currentUser = getCurrent();
            int id = getId(currentUser.Id);
            fitnesProfili = fitnesProfili.FindAll(profil => profil.Id == id);
            return View(fitnesProfili);
        }

        [Authorize(Roles = "Korisnik")]
        // GET: FitnesProfil/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnesProfil = await _context.FitnesProfil
                .FirstOrDefaultAsync(profil => profil.FitnesProfilID == id);
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
            var currentUser = getCurrent();
            int id = getId(currentUser.Id);
            var fitnesProfil = _context.FitnesProfil.Where(profil => profil.Id == id).FirstOrDefault();
            if (fitnesProfil != null)
            {
                return View("Views/FitnesProfil/CreateAccessDenied.cshtml");
            }
            else
            {
                return View();
            }
        }

        // POST: FitnesProfil/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FitnesProfilID,Spol,Level,Starost,Kilaza,Visina,Oprema,Ciljevi,Misici")] FitnesProfil fitnesProfil)
        {
            if (ModelState.IsValid)
            {
                var currentUser = getCurrent();
                fitnesProfil.Id = int.Parse(currentUser.Id);
                _context.Add(fitnesProfil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fitnesProfil);
        }

        [Authorize(Roles = "Korisnik")]
        // GET: FitnesProfil/Edit/
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

        // POST: FitnesProfil/Edit/
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
                    var currentUser = getCurrent();
                    int idCurrentUser = getId(currentUser.Id);
                    var fitnesProgrami = await _context.FitnesProgram.Where(program => program.KorisnikID == idCurrentUser).ToListAsync();
                    _context.FitnesProgram.RemoveRange(fitnesProgrami);
                    fitnesProfil.Id = int.Parse(currentUser.Id);
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
        // GET: FitnesProfil/Delete/
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnesProfil = await _context.FitnesProfil
                .FirstOrDefaultAsync(profil => profil.FitnesProfilID == id);
            if (fitnesProfil == null)
            {
                return NotFound();
            }

            return View(fitnesProfil);
        }

        // POST: FitnesProfil/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currentUser = getCurrent();
            int idCurrentUser = getId(currentUser.Id);
            var fitnesProgrami = await _context.FitnesProgram.Where(program => program.KorisnikID == idCurrentUser).ToListAsync();
            _context.FitnesProgram.RemoveRange(fitnesProgrami);
            var fitnesProfil = await _context.FitnesProfil.FindAsync(id);
            _context.FitnesProfil.Remove(fitnesProfil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FitnesProfilExists(int id)
        {
            return _context.FitnesProfil.Any(profil => profil.FitnesProfilID == id);
        }
    }
}
