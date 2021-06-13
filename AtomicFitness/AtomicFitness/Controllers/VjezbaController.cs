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
using static AtomicFitness.Models.Enums;
using System.Text.RegularExpressions;

namespace AtomicFitness.Controllers
{
    public class VjezbaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VjezbaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Vjezba
        public async Task<IActionResult> Index(string SearchBy, string Search)
        {
            if(SearchBy == "Naziv") 
            {
                return View(await _context.Vjezba.Where(vjezba => Search == null || vjezba.Naziv.Replace(" ","")
                                                 .Equals(Regex.Replace(Search, @"\s", ""), StringComparison.InvariantCultureIgnoreCase))
                                                 .ToListAsync());
            }
            else if (SearchBy == "Oprema")
            {
                return View(await _context.Vjezba.Where(vjezba => Search == null || Enum.GetNames(typeof(Oprema))
                                                 .Contains(Regex.Replace(Search, @"\s", ""), StringComparer.OrdinalIgnoreCase) &&
                                                 vjezba.Oprema.Equals((Oprema)Enum.Parse(typeof(Oprema), 
                                                 Regex.Replace(Search, @"\s", ""),true))).ToListAsync());
            }
            else if(SearchBy == "Level")
            {
                return View(await _context.Vjezba.Where(vjezba => Search == null || 
                                                 Enum.GetNames(typeof(Level)).Contains(Regex.Replace(Search, @"\s", ""), StringComparer.OrdinalIgnoreCase) &&
                                                 vjezba.Level.Equals((Level)Enum.Parse(typeof(Level), Regex.Replace(Search, @"\s", ""), true)))
                                                 .ToListAsync());
            }
            else if (SearchBy == "Misici")
            {
                return View(await _context.Vjezba.Where(x => Search == null || 
                                                    Enum.GetNames(typeof(Misici))
                                                    .Contains(Regex.Replace(Search, @"\s", ""), StringComparer.OrdinalIgnoreCase) && 
                                                    x.Misici.Equals((Misici)Enum.Parse(typeof(Misici), Regex.Replace(Search, @"\s", ""), true)))
                                                    .ToListAsync());
            }
            else
            {
                return View(await _context.Vjezba.ToListAsync());
            }
        }

        [Authorize]
        // GET: Vjezba/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vjezba = await _context.Vjezba
                .FirstOrDefaultAsync(m => m.VjezbaID == id);
            if (vjezba == null)
            {
                return NotFound();
            }

            return View(vjezba);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Vjezba/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vjezba/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VjezbaID,FitnesProgramID,Naziv,Oprema,Level,Misici,BrojPonavljanja,BrojSerija,Opis,Link")] Vjezba vjezba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vjezba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vjezba);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Vjezba/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vjezba = await _context.Vjezba.FindAsync(id);
            if (vjezba == null)
            {
                return NotFound();
            }
            return View(vjezba);
        }

        // POST: Vjezba/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VjezbaID,FitnesProgramID,Naziv,Oprema,Level,Misici,BrojPonavljanja,BrojSerija,Opis,Link")] Vjezba vjezba)
        {
            if (id != vjezba.VjezbaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vjezba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VjezbaExists(vjezba.VjezbaID))
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
            return View(vjezba);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Vjezba/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vjezba = await _context.Vjezba
                .FirstOrDefaultAsync(m => m.VjezbaID == id);
            if (vjezba == null)
            {
                return NotFound();
            }

            return View(vjezba);
        }

        // POST: Vjezba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vjezba = await _context.Vjezba.FindAsync(id);
            _context.Vjezba.Remove(vjezba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VjezbaExists(int id)
        {
            return _context.Vjezba.Any(e => e.VjezbaID == id);
        }
    }
}
