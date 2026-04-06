using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManagementSystem.Core.Entities;
using PropertyManagementSystem.Infrastructure.Data;

namespace PropertyManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BuildingsController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _db.Buildings.AsNoTracking().ToListAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var building = await _db.Buildings.FindAsync(id);
            return building is null ? NotFound() : Ok(building);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Building building)
        {
            _db.Buildings.Add(building);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = building.Id }, building);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Building updated)
        {
            if (id != updated.Id) return BadRequest();
            var exists = await _db.Buildings.AnyAsync(b => b.Id == id);
            if (!exists) return NotFound();
            _db.Entry(updated).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var building = await _db.Buildings.FindAsync(id);
            if (building is null) return NotFound();
            _db.Buildings.Remove(building);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}