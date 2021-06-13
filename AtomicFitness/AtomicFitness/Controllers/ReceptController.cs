using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtomicFitness.Data;
using AtomicFitness.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;

namespace AtomicFitness.Controllers
{
    public class ReceptController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceptController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Recept
        public async Task<IActionResult> Index(string SearchBy, string Search)
        {
            if (SearchBy == "Naziv")
            {
                return View(await _context.Recept.Where(recept => Search == null || recept.Naziv.Replace(" ", "")
                                                 .Equals(Regex.Replace(Search, @"\s", ""), StringComparison.InvariantCultureIgnoreCase))
                                                 .ToListAsync());
            }
            else if (SearchBy == "Sastojci")
            {
                return View(await _context.Recept.Where(recept => Search == null || recept.Sastojci.Replace(" ", "")
                                                 .IndexOf(Regex.Replace(Search, @"\s", ""), StringComparison.OrdinalIgnoreCase) >= 0)
                                                 .ToListAsync());
            }
            else
            {
                return View(await _context.Recept.ToListAsync());
            }
        }

        [Authorize]
        // GET: Recept/Details/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recept = await _context.Recept
                .FirstOrDefaultAsync(recept => recept.ReceptID == id);
            if (recept == null)
            {
                return NotFound();
            }

            return View(recept);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Recept/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recept/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReceptID,Naziv,Sastojci,Opis,Link")] Recept recept)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recept);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recept);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Recept/Edit/
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recept = await _context.Recept.FindAsync(id);
            if (recept == null)
            {
                return NotFound();
            }
            return View(recept);
        }

        // POST: Recept/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReceptID,Naziv,Sastojci,Opis,Link")] Recept recept)
        {
            if (id != recept.ReceptID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recept);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceptExists(recept.ReceptID))
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
            return View(recept);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Recept/Delete/
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recept = await _context.Recept
                .FirstOrDefaultAsync(recept => recept.ReceptID == id);
            if (recept == null)
            {
                return NotFound();
            }

            return View(recept);
        }

        // POST: Recept/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recept = await _context.Recept.FindAsync(id);
            _context.Recept.Remove(recept);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceptExists(int id)
        {
            return _context.Recept.Any(recept => recept.ReceptID == id);
        }
    }
}
