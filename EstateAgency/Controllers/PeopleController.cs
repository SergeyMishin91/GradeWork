using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstateAgency.Data;
using EstateAgency.Models;

namespace EstateAgency.Controllers
{
    public class PeopleController : Controller
    {
        private readonly EstateAgencyContext _context;

        public PeopleController(EstateAgencyContext context)
        {
            _context = context;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            return View(await _context.People.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,Surname,Phone,Adress,ClientStatus")] Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(person);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                ModelState.AddModelError("", "Невозможно сохранить данные. " +
                    "Попробуйте снова. Если проблема останется" +
                    "обратитесь к администратору.");
            }

            return View(person);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People.SingleOrDefaultAsync(m => m.ID == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personToUpdate = await _context.People
                .SingleOrDefaultAsync(f => f.ID == id);
            if (await TryUpdateModelAsync<Person>(
                personToUpdate,
                "",
                p => p.FirstName, p => p.Surname, p => p.Adress, p => p.Phone, p => p.ClientStatus))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Невозможно сохранить данные. " +
                    "Попробуйте снова. Если проблема останется" +
                    "обратитесь к администратору.");
                }
            }
            return View(personToUpdate);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (person == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Данные не удалены. Попробуйте снова, если проблема повториться " +
                    "свяжитесь с администратором.";
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.People
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (person == null)
                return RedirectToAction(nameof(Index));

            try
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.ID == id);
        }
    }
}
