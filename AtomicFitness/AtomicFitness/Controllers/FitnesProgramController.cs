using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        private Korisnik getCurrent()
        {
            return _context.Korisnik.Where(user => user.Email == User.Identity.Name).FirstOrDefault();
        }

        private int getId(string userId)
        {
            return int.Parse(userId);
        }

        [Authorize(Roles = "Korisnik")]
        // GET: FitnesProgram
        public async Task<IActionResult> Index()
        {
            var currentUser = getCurrent();
            int id = getId(currentUser.Id);
            var fitnesProgrami = await _context.FitnesProgram.ToListAsync();
            fitnesProgrami = fitnesProgrami.FindAll(program => program.KorisnikID == id);
            return View(fitnesProgrami);
        }

        [Authorize(Roles = "Korisnik")]
        // GET: FitnesProgram/Details/
        public async Task<IActionResult> Details()
        {
            var currentUser = getCurrent();
            int id = getId(currentUser.Id);
            var idZadnjegPrograma = await _context.FitnesProgram.Where(program => program.KorisnikID == id).MaxAsync(zadnjiProgram => zadnjiProgram.FitnesProgramID);
            var fitnesProgram = await _context.FitnesProgram.FindAsync(idZadnjegPrograma);
            var vjezbe = await _context.Vjezba.Where(vjezba => vjezba.FitnesProgramID == fitnesProgram.FitnesProgramID).ToListAsync();
            return View(vjezbe);
        }

        // POST: FitnesProgram/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FitnesProgram fitnesProgram)
        {
            var currentUser = getCurrent();
            int id = getId(currentUser.Id);
            fitnesProgram.KorisnikID = id;
            _context.Add(fitnesProgram);
            await _context.SaveChangesAsync();
            var vjezbe = await _context.Vjezba.ToListAsync();
            var fitnesProfili = await _context.FitnesProfil.ToListAsync();
            var fitnesProfil = fitnesProfili.Find(profil => profil.Id == id);
            if (fitnesProfil != null)
            {
                vjezbe = vjezbe.FindAll(vjezba => vjezba.Level.Equals(fitnesProfil.Level) && vjezba.Oprema.Equals(fitnesProfil.Oprema) && vjezba.Misici.Equals(fitnesProfil.Misici));
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
        // GET: FitnesProgram/Delete/
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnesProgram = await _context.FitnesProgram
                .FirstOrDefaultAsync(program => program.FitnesProgramID == id);
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
            var currentUser = getCurrent();
            int id = getId(currentUser.Id);
            var fitnesProgram = await _context.FitnesProgram.Where(program => program.KorisnikID == id).FirstOrDefaultAsync();
            _context.FitnesProgram.Remove(fitnesProgram);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FitnesProgramExists(int id)
        {
            return _context.FitnesProgram.Any(program => program.FitnesProgramID == id);
        }
    }
}
