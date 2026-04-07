using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PropertyManagementSystem.Infrastructure.Data;
using System.Linq;
using System.Diagnostics;
using PropertyManagementSystem.Models;

namespace PropertyManagementSystem.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(AppDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.BuildingsCount = _context.Buildings.Count();
            ViewBag.ApartmentsCount = _context.Apartments.Count();
            ViewBag.TenantsCount = _context.Tenants.Count();
            ViewBag.PaymentsCount = _context.Payments.Count();

            var paymentsByMonth = _context.Payments
                .AsNoTracking()
                .GroupBy(p => p.Date.Month)
                .Select(g => new
                {
                    Month = g.Key,
                    Total = g.Sum(x => x.Amount)
                })
                .OrderBy(x => x.Month)
                .ToList();

            ViewBag.PaymentsLabels = System.Text.Json.JsonSerializer.Serialize(
                paymentsByMonth.Select(x => x.Month.ToString())
            );

            ViewBag.PaymentsData = System.Text.Json.JsonSerializer.Serialize(
                paymentsByMonth.Select(x => x.Total)
            );

            var apartments = _context.Apartments
                .Include(a => a.Building)
                .Include(a => a.Tenants)
                .AsNoTracking()
                .ToList();

            var tenantsByBuilding = apartments
                .GroupBy(a => a.Building.Name)
                .Select(g => new
                {
                    Building = g.Key,
                    Tenants = g.Sum(a => a.Tenants.Count)
                })
                .ToList();

            ViewBag.TenantsLabels = System.Text.Json.JsonSerializer.Serialize(
                tenantsByBuilding.Select(x => x.Building)
            );

            ViewBag.TenantsData = System.Text.Json.JsonSerializer.Serialize(
                tenantsByBuilding.Select(x => x.Tenants)
            );

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}