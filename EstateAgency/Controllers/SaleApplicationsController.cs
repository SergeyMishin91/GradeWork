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
    public class SaleApplicationsController : Controller
    {
        private readonly EstateAgencyContext _context;

        public SaleApplicationsController(EstateAgencyContext context)
        {
            _context = context;
        }

        // GET: SaleApplications
        public async Task<IActionResult> Index()
        {
            return View(await _context.SaleApplications.ToListAsync());
        }

        // GET: SaleApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleApplication = await _context.SaleApplications
                .SingleOrDefaultAsync(m => m.ID == id);
            if (saleApplication == null)
            {
                return NotFound();
            }

            return View(saleApplication);
        }

        // GET: SaleApplications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaleApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalePrice,ClientName,Phone,ContactPerson,EstateType,EstateArea,OtherRequirements")] SaleApplication saleApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleApplication);
        }

       
        // GET: SaleApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleApplication = await _context.SaleApplications
                .SingleOrDefaultAsync(m => m.ID == id);
            if (saleApplication == null)
            {
                return NotFound();
            }

            return View(saleApplication);
        }

        // POST: SaleApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleApplication = await _context.SaleApplications.SingleOrDefaultAsync(m => m.ID == id);
            _context.SaleApplications.Remove(saleApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleApplicationExists(int id)
        {
            return _context.SaleApplications.Any(e => e.ID == id);
        }
    }
}
