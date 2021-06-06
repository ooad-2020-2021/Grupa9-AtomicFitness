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
using System.Web;
using System.Text.RegularExpressions;

namespace AtomicFitness.Controllers
{
    public class PjesmaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PjesmaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Pjesma
        public async Task<IActionResult> Index(string SearchBy, string Search)
        {

            if (SearchBy == "Naziv")
            {
                return View(await _context.Pjesma.Where(x => Search == null || x.Naziv.Replace(" ", "").Equals(Regex.Replace(Search, @"\s", ""), StringComparison.InvariantCultureIgnoreCase)).ToListAsync());
            }
            else if (SearchBy == "Pjevaci")
            {
                return View(await _context.Pjesma.Where(x => Search == null || x.Pjevaci.Replace(" ", "").IndexOf(Regex.Replace(Search, @"\s", ""), StringComparison.OrdinalIgnoreCase) >= 0).ToListAsync());
            }
            else if (SearchBy == "Zanr")
            {
                return View(await _context.Pjesma.Where(x => Search == null || x.Zanr.Replace(" ", "").Equals(Regex.Replace(Search, @"\s", ""), StringComparison.InvariantCultureIgnoreCase)).ToListAsync());
            }
            else
            {
                return View(await _context.Pjesma.ToListAsync());
            };
        }

        [Authorize]
        // GET: Pjesma/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pjesma = await _context.Pjesma
                .FirstOrDefaultAsync(m => m.PjesmaID == id);
            if (pjesma == null)
            {
                return NotFound();
            }

            return View(pjesma);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Pjesma/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pjesma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PjesmaID,Naziv,Pjevaci,Zanr,GodinaIzdanja,Link")] Pjesma pjesma)
        {
            if (ModelState.IsValid)
            {
                var url = pjesma.Link;
                var uri = new Uri(url);
                var query = HttpUtility.ParseQueryString(uri.Query);
                var videoId = string.Empty;
                if (query.AllKeys.Contains("v"))
                {
                    videoId = query["v"];
                }
                else
                {
                    videoId = uri.Segments.Last();
                }
                pjesma.Link = "https://www.youtube.com/embed/" + videoId;
                _context.Add(pjesma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pjesma);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Pjesma/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pjesma = await _context.Pjesma.FindAsync(id);
            if (pjesma == null)
            {
                return NotFound();
            }
            return View(pjesma);
        }

        // POST: Pjesma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PjesmaID,Naziv,Pjevaci,Zanr,GodinaIzdanja,Link")] Pjesma pjesma)
        {
            if (id != pjesma.PjesmaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var url = pjesma.Link;
                    var uri = new Uri(url);
                    var query = HttpUtility.ParseQueryString(uri.Query);
                    var videoId = string.Empty;
                    if (query.AllKeys.Contains("v"))
                    {
                        videoId = query["v"];
                    }
                    else
                    {
                        videoId = uri.Segments.Last();
                    }
                    pjesma.Link = "https://www.youtube.com/embed/" + videoId;
                    _context.Update(pjesma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PjesmaExists(pjesma.PjesmaID))
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
            return View(pjesma);
        }

        [Authorize(Roles = "Administrator")]
        // GET: Pjesma/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pjesma = await _context.Pjesma
                .FirstOrDefaultAsync(m => m.PjesmaID == id);
            if (pjesma == null)
            {
                return NotFound();
            }

            return View(pjesma);
        }

        // POST: Pjesma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pjesma = await _context.Pjesma.FindAsync(id);
            _context.Pjesma.Remove(pjesma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PjesmaExists(int id)
        {
            return _context.Pjesma.Any(e => e.PjesmaID == id);
        }
    }
}
