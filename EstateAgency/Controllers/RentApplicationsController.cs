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
    public class RentApplicationsController : Controller
    {
        private readonly EstateAgencyContext _context;

        public RentApplicationsController(EstateAgencyContext context)
        {
            _context = context;
        }

        // GET: RentApplications
        public async Task<IActionResult> Index()
        {
            return View(await _context.RentApplications.ToListAsync());
        }

        // GET: RentApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentApplication = await _context.RentApplications
                .SingleOrDefaultAsync(m => m.ID == id);
            if (rentApplication == null)
            {
                return NotFound();
            }

            return View(rentApplication);
        }

        // GET: RentApplications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RentApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentPrice,ClientName,Phone,ContactPerson,EstateType,EstateArea,OtherRequirements")] RentApplication rentApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentApplication);
        }

        // GET: RentApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentApplication = await _context.RentApplications
                .SingleOrDefaultAsync(m => m.ID == id);
            if (rentApplication == null)
            {
                return NotFound();
            }

            return View(rentApplication);
        }

        // POST: RentApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentApplication = await _context.RentApplications.SingleOrDefaultAsync(m => m.ID == id);
            _context.RentApplications.Remove(rentApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentApplicationExists(int id)
        {
            return _context.RentApplications.Any(e => e.ID == id);
        }
    }
}
