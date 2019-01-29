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
    public class SaleTreatiesController : Controller
    {
        private readonly EstateAgencyContext _context;

        public SaleTreatiesController(EstateAgencyContext context)
        {
            _context = context;
        }

        // GET: SaleTreaties
        public async Task<IActionResult> Index()
        {
            return View(await _context.SaleTreaties.ToListAsync());
        }

        // GET: SaleTreaties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleTreaty = await _context.SaleTreaties
                .Include(s => s.Estates)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (saleTreaty == null)
            {
                return NotFound();
            }

            return View(saleTreaty);
        }

        // GET: SaleTreaties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaleTreaties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("TotalSalePrice,Number,SignDate")] SaleTreaty saleTreaty)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(saleTreaty);
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
            return View(saleTreaty);
        }

        // GET: SaleTreaties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleTreaty = await _context.SaleTreaties.SingleOrDefaultAsync(m => m.ID == id);
            if (saleTreaty == null)
            {
                return NotFound();
            }
            return View(saleTreaty);
        }

        // POST: SaleTreaties/Edit/5
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
            var saleTreatyToUpdate = await _context.SaleTreaties.SingleOrDefaultAsync(s => s.ID == id);
            if (await TryUpdateModelAsync<SaleTreaty>(
                saleTreatyToUpdate,
                "",
                s => s.Number, s => s.SignDate, s => s.TotalSalePrice))
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
            return View(saleTreatyToUpdate);
        }

        // GET: SaleTreaties/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleTreaty = await _context.SaleTreaties
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (saleTreaty == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Данные не удалены. Попробуйте снова, если проблема повториться " +
                    "свяжитесь с администратором.";
            }

            return View(saleTreaty);
        }

        // POST: SaleTreaties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleTreaty = await _context.SaleTreaties
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (saleTreaty == null)
                return RedirectToAction(nameof(Index));
            try
            {
                _context.SaleTreaties.Remove(saleTreaty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool SaleTreatyExists(int id)
        {
            return _context.SaleTreaties.Any(e => e.ID == id);
        }
    }
}
