using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Studenti.Data;
using Studenti.Models;

namespace Studenti.Controllers
{
    public class LabVezbasController : Controller
    {
        private readonly StudentiContext _context;

        public LabVezbasController(StudentiContext context)
        {
            _context = context;
        }

        // GET: LabVezbas
        public async Task<IActionResult> Index(string searchString1, string searchString2)
        {
            var allLabs = await _context.LabVezba.ToListAsync();
            if (!String.IsNullOrEmpty(searchString1))
            {

                allLabs = allLabs.Where(n => n.Naslov.Contains(searchString1, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!String.IsNullOrEmpty(searchString2))
            {

                allLabs = allLabs.Where(n => n.Opis.Contains(searchString2, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return View(allLabs);
        }

        // GET: LabVezbas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labVezba = await _context.LabVezba
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labVezba == null)
            {
                return NotFound();
            }

            return View(labVezba);
        }

        // GET: LabVezbas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LabVezbas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naslov,Opis")] LabVezba labVezba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labVezba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labVezba);
        }

        // GET: LabVezbas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labVezba = await _context.LabVezba.FindAsync(id);
            if (labVezba == null)
            {
                return NotFound();
            }
            return View(labVezba);
        }

        // POST: LabVezbas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naslov,Opis")] LabVezba labVezba)
        {
            if (id != labVezba.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labVezba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabVezbaExists(labVezba.Id))
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
            return View(labVezba);
        }

        // GET: LabVezbas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labVezba = await _context.LabVezba
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labVezba == null)
            {
                return NotFound();
            }

            return View(labVezba);
        }

        // POST: LabVezbas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labVezba = await _context.LabVezba.FindAsync(id);
            if (labVezba != null)
            {
                _context.LabVezba.Remove(labVezba);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabVezbaExists(int id)
        {
            return _context.LabVezba.Any(e => e.Id == id);
        }

    }
}
