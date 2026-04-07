using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropertyManagementSystem.Core.Entities;
using PropertyManagementSystem.Infrastructure.Data;

namespace PropertyManagementSystem.Controllers
{
    [Authorize]
    public class ApartmentsController : Controller
    {
        private readonly AppDbContext _context;

        public ApartmentsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var apartments = await _context.Apartments
                .Include(a => a.Building)
                .ToListAsync();

            return View(apartments);
        }

        public IActionResult Create()
        {
            ViewBag.Buildings = new SelectList(_context.Buildings, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Apartment apartment)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Buildings = new SelectList(_context.Buildings, "Id", "Name", apartment.BuildingId);
                return View(apartment);
            }

            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null)
                return NotFound();

            ViewBag.Buildings = new SelectList(_context.Buildings, "Id", "Name", apartment.BuildingId);
            return View(apartment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Apartment apartment)
        {
            if (id != apartment.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                ViewBag.Buildings = new SelectList(_context.Buildings, "Id", "Name", apartment.BuildingId);
                return View(apartment);
            }

            _context.Update(apartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var apartment = await _context.Apartments
                .Include(a => a.Building)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (apartment == null)
                return NotFound();

            return View(apartment);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var apartment = await _context.Apartments
                .Include(a => a.Building)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (apartment == null)
                return NotFound();

            return View(apartment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null)
                return NotFound();

            _context.Apartments.Remove(apartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}