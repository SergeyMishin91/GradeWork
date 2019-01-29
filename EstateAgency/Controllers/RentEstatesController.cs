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
    public class RentEstatesController : Controller
    {
        private readonly EstateAgencyContext _context;

        public RentEstatesController(EstateAgencyContext context)
        {
            _context = context;
        }

        // GET: RentEstates
        public async Task<IActionResult> Index()
        {
            var estateAgencyContext = _context.RentEstates.Include(r => r.Owner);
            return View(await estateAgencyContext.ToListAsync());
        }

        // GET: RentEstates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentEstate = await _context.RentEstates
                .Include(r => r.Owner)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (rentEstate == null)
            {
                return NotFound();
            }

            return View(rentEstate);
        }

        // GET: RentEstates/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "ID");
            return View();
        }

        // POST: RentEstates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("RentPrice,Name,Type,InventoryNumber,Year,Wall,Area,Adress,ShortDescription,LongDescription,ImageURL,ImageThumbURL,SaleStatus,ClientID")] RentEstate rentEstate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(rentEstate);
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

            return View(rentEstate);
        }

        // GET: RentEstates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentEstate = await _context.RentEstates.SingleOrDefaultAsync(m => m.ID == id);
            if (rentEstate == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "ID", rentEstate.ClientID);
            return View(rentEstate);
        }

        // POST: RentEstates/Edit/5
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

            var rentEstateToUpdate = await _context.RentEstates
                .SingleOrDefaultAsync(e => e.ID == id);
            if (await TryUpdateModelAsync<RentEstate>(
                rentEstateToUpdate,
                "",
                e => e.Name, e => e.Type, e => e.InventoryNumber, e => e.Year, e => e.Wall, e => e.Area, e => e.Adress, e => e.ShortDescription,
                e => e.LongDescription, e => e.ImageURL, e => e.ImageThumbURL, e => e.SaleStatus, e => e.PerSquareMeterRentPrice, e => e.ClientID))
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
            return View(rentEstateToUpdate);
        }

        // GET: RentEstates/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentEstate = await _context.RentEstates
                .AsNoTracking()
                .Include(r => r.Owner)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (rentEstate == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Данные не удалены. Попробуйте снова, если проблема повториться " +
                    "свяжитесь с администратором.";
            }

            return View(rentEstate);
        }

        // POST: RentEstates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentEstate = await _context.RentEstates
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (rentEstate == null)
                return RedirectToAction(nameof(Index));

            try
            {
                _context.RentEstates.Remove(rentEstate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }

        }

        private bool RentEstateExists(int id)
        {
            return _context.RentEstates.Any(e => e.ID == id);
        }
    }
}
