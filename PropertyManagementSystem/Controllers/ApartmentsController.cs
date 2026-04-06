using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManagementSystem.Core.Entities;
using PropertyManagementSystem.Infrastructure.Data;

namespace PropertyManagementSystem.Controllers
{
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

        public async Task<IActionResult> Details(int id)
        {
            var apartment = await _context.Apartments
                .Include(a => a.Building)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (apartment == null)
                return NotFound();

            return View(apartment);
        }

        public IActionResult Create()
        {
            ViewBag.Buildings = _context.Buildings.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Apartment apartment)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Buildings = _context.Buildings.ToList();
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

            ViewBag.Buildings = _context.Buildings.ToList();
            return View(apartment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Apartment apartment)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Buildings = _context.Buildings.ToList();
                return View(apartment);
            }

            _context.Apartments.Update(apartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment != null)
            {
                _context.Apartments.Remove(apartment);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}