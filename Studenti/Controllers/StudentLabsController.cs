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
    public class StudentLabsController : Controller
    {
        private readonly StudentiContext _context;

        public StudentLabsController(StudentiContext context)
        {
            _context = context;
        }

        // GET: StudentLabs
        public async Task<IActionResult> Index(int id)
        {
            var kolokvium3105Context = _context.StudentLab.Where(s => s.LabVezbaId == id).Include(s => s.LabVezba).Include(s => s.Student);
            return View(await kolokvium3105Context.ToListAsync());
        }

        // GET: StudentLabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentLab = await _context.StudentLab
                .Include(s => s.LabVezba)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentLab == null)
            {
                return NotFound();
            }

            return View(studentLab);
        }

        // GET: StudentLabs/Create
        public IActionResult Create()
        {
            ViewData["LabVezbaId"] = new SelectList(_context.LabVezba, "Id", "Naslov");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "ImePrezime");
            return View();
        }

        // POST: StudentLabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,LabVezbaId,Zavrsena,Poeni,DataZavrsuvanje")] StudentLab studentLab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentLab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LabVezbaId"] = new SelectList(_context.LabVezba, "Id", "Naslov", studentLab.LabVezbaId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "ImePrezime", studentLab.StudentId);
            return View(studentLab);
        }

        // GET: StudentLabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentLab = await _context.StudentLab.FindAsync(id);
            if (studentLab == null)
            {
                return NotFound();
            }
            ViewData["LabVezbaId"] = new SelectList(_context.LabVezba, "Id", "Naslov", studentLab.LabVezbaId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "ImePrezime", studentLab.StudentId);
            return View(studentLab);
        }

        // POST: StudentLabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,LabVezbaId,Zavrsena,Poeni,DataZavrsuvanje")] StudentLab studentLab)
        {
            if (id != studentLab.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentLab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentLabExists(studentLab.Id))
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
            ViewData["LabVezbaId"] = new SelectList(_context.LabVezba, "Id", "Naslov", studentLab.LabVezbaId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "ImePrezime", studentLab.StudentId);
            return View(studentLab);
        }

        // GET: StudentLabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentLab = await _context.StudentLab
                .Include(s => s.LabVezba)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentLab == null)
            {
                return NotFound();
            }

            return View(studentLab);
        }

        // POST: StudentLabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentLab = await _context.StudentLab.FindAsync(id);
            if (studentLab != null)
            {
                _context.StudentLab.Remove(studentLab);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentLabExists(int id)
        {
            return _context.StudentLab.Any(e => e.Id == id);
        }


        //public async Task<IActionResult> Students(int? labVezbaId)
        //{
        //    if (labVezbaId == null)
        //    {
        //        return NotFound();
        //    }

        //    var labVezba = await _context.LabVezba
        //        .Include(l => l.Students)
        //            .ThenInclude(sl => sl.Student)
        //        .FirstOrDefaultAsync(l => l.Id == labVezbaId);

        //    if (labVezba == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(labVezba);
        //}



    }
}
