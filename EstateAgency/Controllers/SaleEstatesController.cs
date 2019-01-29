using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstateAgency.Data;
using EstateAgency.Models;
using System;

namespace EstateAgency.Controllers
{
    public class SaleEstatesController : Controller
    {
        private readonly EstateAgencyContext _context;

        public SaleEstatesController(EstateAgencyContext context)
        {
            _context = context;
        }

        // GET: SaleEstates
        public async Task<IActionResult> Index()
        {
            var estateAgencyContext = _context.SaleEstates.Include(s => s.Owner);
            return View(await estateAgencyContext.ToListAsync());
        }

        // GET: SaleEstates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleEstate = await _context.SaleEstates
                .Include(s => s.Owner)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (saleEstate == null)
            {
                return NotFound();
            }

            return View(saleEstate);
        }

        // GET: SaleEstates/Create
        public IActionResult Create()
        {
            ClientsDropDownList();
            return View();
        }

        // POST: SaleEstates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("SalePrice,Name,Type,InventoryNumber,Year,Wall,Area,Adress,ShortDescription,LongDescription,ImageURL,ImageThumbURL,SaleStatus,ClientID")] SaleEstate saleEstate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(saleEstate);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Невозможно сохранить данные. " +
                    "Попробуйте снова. Если проблема останется" +
                    "обратитесь к администратору.");
            }
            ClientsDropDownList(saleEstate.ClientID);
            return View(saleEstate);
        }

        // GET: SaleEstates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleEstate = await _context.SaleEstates.SingleOrDefaultAsync(m => m.ID == id);
            if (saleEstate == null)
            {
                return NotFound();
            }
            //ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "ID", saleEstate.ClientID);
            ClientsDropDownList(saleEstate.ClientID);
            return View(saleEstate);
        }

        // POST: SaleEstates/Edit/5
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

            var saleEstateToUpdate = await _context.SaleEstates
                .SingleOrDefaultAsync(e => e.ID == id);
            if (await TryUpdateModelAsync<SaleEstate>(
                saleEstateToUpdate,
                "",
                e => e.Name, e => e.Type, e => e.InventoryNumber, e => e.Year, e => e.Wall, e => e.Area, e => e.Adress, e => e.ShortDescription,
                e => e.LongDescription, e => e.ImageURL, e => e.ImageThumbURL, e => e.SaleStatus, e => e.SalePrice, e => e.ClientID))
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
            ClientsDropDownList(saleEstateToUpdate.ClientID);
            return View(saleEstateToUpdate);
        }

        private void ClientsDropDownList(object selectedClient = null)
        {
            var clientsQuery = from c in _context.Clients
                               where c.ClientStatus == ClientStatus.Owner
                               orderby c.FullName
                               select c;
            ViewBag.ID = new SelectList(clientsQuery.AsNoTracking(), "ID", "FullName", selectedClient);
        }

        // GET: SaleEstates/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleEstate = await _context.SaleEstates
                .AsNoTracking()
                .Include(s => s.Owner)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (saleEstate == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Данные не удалены. Попробуйте снова, если проблема повториться " +
                    "свяжитесь с администратором.";
            }

            return View(saleEstate);
        }

        // POST: SaleEstates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleEstate = await _context.SaleEstates
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (saleEstate == null)
                return RedirectToAction(nameof(Index));
            try
            {
                _context.SaleEstates.Remove(saleEstate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
            
        }

        private bool SaleEstateExists(int id)
        {
            return _context.SaleEstates.Any(e => e.ID == id);
        }
    }
}
