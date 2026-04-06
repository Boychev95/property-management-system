using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManagementSystem.Core.Entities;
using PropertyManagementSystem.Infrastructure.Data;

namespace PropertyManagementSystem.Controllers
{
    public class TenantsController : Controller
    {
        private readonly AppDbContext _context;

        public TenantsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tenants = await _context.Tenants
                .Include(t => t.Apartment)
                .ThenInclude(a => a.Building)
                .ToListAsync();

            return View(tenants);
        }

        public IActionResult Create()
        {
            ViewBag.Apartments = _context.Apartments
                .Include(a => a.Building)
                .ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tenant tenant)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Apartments = _context.Apartments
                    .Include(a => a.Building)
                    .ToList();

                return View(tenant);
            }

            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tenant = await _context.Tenants.FindAsync(id);
            if (tenant == null)
                return NotFound();

            ViewBag.Apartments = _context.Apartments
                .Include(a => a.Building)
                .ToList();

            return View(tenant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tenant tenant)
        {
            if (id != tenant.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                ViewBag.Apartments = _context.Apartments
                    .Include(a => a.Building)
                    .ToList();

                return View(tenant);
            }

            _context.Update(tenant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var tenant = await _context.Tenants
                .Include(t => t.Apartment)
                .ThenInclude(a => a.Building)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tenant == null)
                return NotFound();

            return View(tenant);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tenant = await _context.Tenants
                .Include(t => t.Apartment)
                .ThenInclude(a => a.Building)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tenant == null)
                return NotFound();

            return View(tenant);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>