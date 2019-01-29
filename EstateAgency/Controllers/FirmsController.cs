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
    public class FirmsController : Controller
    {
        private readonly EstateAgencyContext _context;

        public FirmsController(EstateAgencyContext context)
        {
            _context = context;
        }

        // GET: Firms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Firms.ToListAsync());
        }

        // GET: Firms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firm = await _context.Firms
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (firm == null)
            {
                return NotFound();
            }

            return View(firm);
        }

        // GET: Firms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Firms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyName,UNP,Phone,Adress,ClientStatus")] Firm firm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(firm);
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

            return View(firm);
        }

        // GET: Firms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firm = await _context.Firms.SingleOrDefaultAsync(m => m.ID == id);
            if (firm == null)
            {
                return NotFound();
            }
            return View(firm);
        }

        // POST: Firms/Edit/5
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

            var firmToUpdate = await _context.Firms
                .SingleOrDefaultAsync(f => f.ID == id);
            if (await TryUpdateModelAsync<Firm>(
                firmToUpdate,
                "",
                f=> f.CompanyName, f => f.UNP, f => f.Adress, f => f.Phone, f => f.ClientStatus))
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
            return View(firmToUpdate);
        }

        // GET: Firms/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firm = await _context.Firms
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (firm == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Данные не удалены. Попробуйте снова, если проблема повториться " +
                    "свяжитесь с администратором.";
            }

            return View(firm);
        }

        // POST: Firms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var firm = await _context.Firms
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (firm == null)
                return RedirectToAction(nameof(Index));

            try
            {
                _context.Firms.Remove(firm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool FirmExists(int id)
        {
            return _context.Firms.Any(e => e.ID == id);
        }
    }
}
