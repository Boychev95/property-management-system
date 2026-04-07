using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PropertyManagementSystem.Core.Entities;

namespace PropertyManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Building>()
                .HasMany(b => b.Apartments)
                .WithOne(a => a.Building)
                .HasForeignKey(a => a.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Apartment>()
                .HasMany(a => a.Tenants)
                .WithOne(t => t.Apartment)
                .HasForeignKey(t => t.ApartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Tenant>()
                .HasMany<Payment>()
                .WithOne(p => p.Tenant)
                .HasForeignKey(p => p.TenantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}