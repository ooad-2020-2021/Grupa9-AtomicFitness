﻿using System;
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
            return View(await _context.FitnesProgram.ToListAsync());
        }

        [Authorize(Roles = "Korisnik")]
        // GET: FitnesProgram/Details/5
        public async Task<IActionResult> Details(int? id)
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

        [Authorize(Roles = "Korisnik")]
        // GET: FitnesProgram/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FitnesProgram/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FitnesProgramID,KorisnikID")] FitnesProgram fitnesProgram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fitnesProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fitnesProgram);
        }

        [Authorize(Roles = "Korisnik")]
        // GET: FitnesProgram/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnesProgram = await _context.FitnesProgram.FindAsync(id);
            if (fitnesProgram == null)
            {
                return NotFound();
            }
            return View(fitnesProgram);
        }

        // POST: FitnesProgram/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FitnesProgramID,KorisnikID")] FitnesProgram fitnesProgram)
        {
            if (id != fitnesProgram.FitnesProgramID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fitnesProgram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FitnesProgramExists(fitnesProgram.FitnesProgramID))
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
            return View(fitnesProgram);
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fitnesProgram = await _context.FitnesProgram.FindAsync(id);
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