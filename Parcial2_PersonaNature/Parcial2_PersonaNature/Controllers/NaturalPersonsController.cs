using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial2_PersonaNature.DAL;
using Parcial2_PersonaNature.DAL.Entities;

namespace Parcial2_PersonaNature.Controllers
{
    public class NaturalPersonsController : Controller
    {
        private readonly DataBaseContext _context;

        public NaturalPersonsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: NaturalPersons
        public async Task<IActionResult> Index()
        {
              return _context.NaturalPerson != null ? 
                          View(await _context.NaturalPerson.ToListAsync()) :
                          Problem("Entity set 'DataBaseContext.NaturalPerson'  is null.");
        }

        // GET: NaturalPersons/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.NaturalPerson == null)
            {
                return NotFound();
            }

            var naturalPerson = await _context.NaturalPerson
                .FirstOrDefaultAsync(m => m.id == id);
            if (naturalPerson == null)
            {
                return NotFound();
            }

            return View(naturalPerson);
        }

        // GET: NaturalPersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NaturalPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,Email,BirthYear,Age,id,CreatedDate,ModifiedDate")] NaturalPerson naturalPerson)
        {
            if (ModelState.IsValid)
            {
                naturalPerson.id = Guid.NewGuid();
                naturalPerson.Age= calculatedate(naturalPerson.BirthYear);
                _context.Add(naturalPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(naturalPerson);
        }

        // GET: NaturalPersons/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.NaturalPerson == null)
            {
                return NotFound();
            }

            var naturalPerson = await _context.NaturalPerson.FindAsync(id);
            if (naturalPerson == null)
            {
                return NotFound();
            }
            return View(naturalPerson);
        }

        // POST: NaturalPersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FullName,Email,BirthYear,Age,id,CreatedDate,ModifiedDate")] NaturalPerson naturalPerson)
        {
            if (id != naturalPerson.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(naturalPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NaturalPersonExists(naturalPerson.id))
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
            return View(naturalPerson);
        }



        // GET: NaturalPersons/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.NaturalPerson == null)
            {
                return NotFound();
            }

            var naturalPerson = await _context.NaturalPerson
                .FirstOrDefaultAsync(m => m.id == id);
            if (naturalPerson == null)
            {
                return NotFound();
            }

            return View(naturalPerson);
        }

        // POST: NaturalPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.NaturalPerson == null)
            {
                return Problem("Entity set 'DataBaseContext.NaturalPerson'  is null.");
            }
            var naturalPerson = await _context.NaturalPerson.FindAsync(id);
            if (naturalPerson != null)
            {
                _context.NaturalPerson.Remove(naturalPerson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NaturalPersonExists(Guid id)
        {
          return (_context.NaturalPerson?.Any(e => e.id == id)).GetValueOrDefault();
        }


        private int calculatedate( int bornYear)
        {
            DateTime currentDate = DateTime.Now;
            DateTime bornDate = new DateTime(bornYear, 01, 01);

            int age = currentDate.Year - bornDate.Year;

            return age;


        }

    }

}
