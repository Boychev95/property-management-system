using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManagementSystem.Core.Entities;
using PropertyManagementSystem.Infrastructure.Data;

namespace PropertyManagementSystem.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var payments = await _context.Payments
                .Include(p => p.Tenant)
                .ThenInclude(t => t.Apartment)
                .ToListAsync();

            return View(payments);
        }

        public async Task<IActionResult> Details(int id)
        {
            var payment = await _context.Payments
                .Include(p => p.Tenant)
                .ThenInclude(t => t.Apartment)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (payment == null)
                return NotFound();

            return View(payment);
        }

        public IActionResult Create()
        {
            ViewBag.Tenants = _context.Tenants
                .Include(t => t.Apartment)
                .ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Tenants = _context.Tenants.ToList();
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

            ViewBag.Tenants = _context.Tenants.ToList();
            return View(payment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Tenants = _context.Tenants.ToList();
                return View(payment);
            }

            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var payment = await _context.Payments
                .Include(p => p.Tenant)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (payment == null)
                return NotFound();

            return View(payment);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}