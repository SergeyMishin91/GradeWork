using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstateAgency.Data;
using EstateAgency.Models;
using EstateAgency.Models.ViewModels;

namespace EstateAgency.Controllers
{
    public class LeasesController : Controller
    {
        private readonly EstateAgencyContext _context;

        public LeasesController(EstateAgencyContext context)
        {
            _context = context;
        }

        // GET: Leases
        public async Task<IActionResult> Index(int? id)
        {
            var viewModel = new LeaseIndexData();
            viewModel.Leases = await _context.Leases
                .Include(ls => ls.Client_Treaties)
                    .ThenInclude(ls => ls.Client)
                .Include(ls => ls.RentEstate_Leases)
                    .ThenInclude(ls => ls.Estate)
                .AsNoTracking()
                .OrderBy(ls => ls.SignDate)
                .ToListAsync();

            if ((id != null)&&(viewModel.Leases != null))
            {
                ViewData["LeaseID"] = id.Value;
                Lease lease = viewModel.Leases.Where(
                    ls => ls.ID == id.Value).Single();
                viewModel.Estates = lease.RentEstate_Leases.Select(r => r.Estate);
            }

            //if (id != null)
            //{
            //    ViewData[""]
            //}

            return View(viewModel);
            //return View(await _context.Leases.ToListAsync());
        }

        // GET: Leases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lease = await _context.Leases
                .Include(l => l.RentEstate_Leases)
                    .ThenInclude(l => l.Estate)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (lease == null)
            {
                return NotFound();
            }

            return View(lease);
        }

        // GET: Leases/Create
        public IActionResult Create()
        {
            var lease = new Lease();
            lease.RentEstate_Leases = new List<RentEstate_Lease>();
            PopulateRentEstateLeasesData(lease);
            return View();
        }

        private void PopulateRentEstateLeasesData(Lease lease)
        {
            var allEstates = _context.RentEstates;
            var leaseRentEstates = new HashSet<int>(lease.RentEstate_Leases.Select(e => e.EstateID));
            var viewModel = new List<RentEstate_Lease>();
            foreach (var estate in allEstates)
            {
                viewModel.Add(new RentEstate_Lease
                {
                    EstateID = estate.ID
                });
            }
            ViewData["Estates"] = viewModel;
        }

        // POST: Leases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("TotalRentPrice,Area,EndDate,Number,SignDate")] Lease lease)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(lease);
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

            return View(lease);
        }

        // GET: Leases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lease = await _context.Leases.SingleOrDefaultAsync(m => m.ID == id);
            if (lease == null)
            {
                return NotFound();
            }
            return View(lease);
        }

        // POST: Leases/Edit/5
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

            var leaseToUpdate = await _context.Leases.SingleOrDefaultAsync(l => l.ID == id);
            if (await TryUpdateModelAsync<Lease>(
                leaseToUpdate,
                "",
                l => l.Number, l => l.SignDate, l => l.EndDate, l => l.TotalRentPrice, l => l.Area))
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
            return View(leaseToUpdate);
        }

        // GET: Leases/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lease = await _context.Leases
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (lease == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Данные не удалены. Попробуйте снова, если проблема повториться " +
                    "свяжитесь с администратором.";
            }

            return View(lease);
        }

        // POST: Leases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lease = await _context.Leases
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (lease == null)
                return RedirectToAction(nameof(Index));
            try
            {
                _context.Leases.Remove(lease);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            catch (DbUpdateException /* ex */)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }

        }

        private bool LeaseExists(int id)
        {
            return _context.Leases.Any(e => e.ID == id);
        }
    }
}
