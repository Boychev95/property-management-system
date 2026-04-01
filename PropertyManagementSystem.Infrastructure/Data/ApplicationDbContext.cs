using Microsoft.EntityFrameworkCore;
using PropertyManagementSystem.Core.Entities;

namespace PropertyManagementSystem.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext  
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Building> Buildings { get; set; } = null!;
    }
}