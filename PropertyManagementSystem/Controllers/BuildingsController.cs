using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManagementSystem.Core.Entities;
using PropertyManagementSystem.Infrastructure.Data;

namespace PropertyManagementSystem.Controllers
{
    [Authorize]
    public class BuildingsController : Controller
    {
        private readonly AppDbContext _context;

        public BuildingsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var buildings = await _context.Buildings.ToListAsync();
            return View(buildings);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Building building)
        {
            if (!ModelState.IsValid)
                return View(building);

            _context.Buildings.Add(building);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var building = await _context.Buildings.FindAsync(id);
            if (building == null)
                return NotFound();

            return View(building);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Building building)
        {
            if (id != building.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(building);

            _context.Update(building);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var building = await _context.Buildings.FindAsync(id);
            if (building == null)
                return NotFound();

            return View(building);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var building = await _context.Buildings.FindAsync(id);
            if (building == null)
                return NotFound();

            return View(building);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var building = await _context.Buildings.FindAsync(id);
            if (building == null)
                return NotFound();

            _context.Buildings.Remove(building);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}