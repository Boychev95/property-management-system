using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropertyManagementSystem.Core.Entities;
using PropertyManagementSystem.Infrastructure.Data;

namespace PropertyManagementSystem.Controllers
{
    [Authorize]
    public class PaymentsController : Controller
    {
        private readonly AppDbContext _context;

        public PaymentsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var payments = await _context.Payments
                .Include(p => p.Tenant)
                .ThenInclude(t => t.Apartment)
                .ThenInclude(a => a.Building)
                .ToListAsync();

            return View(payments);
        }

        public IActionResult Create()
        {
            ViewBag.Tenants = _context.Tenants
                .Include(t => t.Apartment)
                .ThenInclude(a => a.Building)
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = $"{t.Name} – {t.Apartment.Number} ({t.Apartment.Building.Name})"
                })
                .ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Tenants = _context.Tenants
                    .Include(t => t.Apartment)
                    .ThenInclude(a => a.Building)
                    .Select(t => new SelectListItem
                    {
                        Value = t.Id.ToString(),
                        Text = $"{t.Name} – {t.Apartment.Number} ({t.Apartment.Building.Name})"
                    })
                    .ToList();

                return View(payment);
            }

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
                return NotFound();

            ViewBag.Tenants = _context.Tenants
                .Include(t => t.Apartment)
                .ThenInclude(a => a.Building)
                .Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = $"{t.Name} – {t.Apartment.Number} ({t.Apartment.Building.Name})"
                })
                .ToList();

            return View(payment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Payment payment)
        {
            if (id != payment.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                ViewBag.Tenants = _context.Tenants
                    .Include(t => t.Apartment)
                    .ThenInclude(a => a.Building)
                    .Select(t => new SelectListItem
                    {
                        Value = t.Id.ToString(),
                        Text = $"{t.Name} – {t.Apartment.Number} ({t.Apartment.Building.Name})"
                    })
                    .ToList();

                return View(payment);
            }

            _context.Update(payment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var payment = await _context.Payments
                .Include(p => p.Tenant)
                .ThenInclude(t => t.Apartment)
                .ThenInclude(a => a.Building)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (payment == null)
                return NotFound();

            return View(payment);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var payment = await _context.Payments
                .Include(p => p.Tenant)
                .ThenInclude(t => t.Apartment)
                .ThenInclude(a => a.Building)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (payment == null)
                return NotFound();

            return View(payment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
                return NotFound();

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}