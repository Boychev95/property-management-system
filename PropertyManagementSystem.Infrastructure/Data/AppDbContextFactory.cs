using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PropertyManagementSystem.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=PropertyManagementDb;User Id=sa;Password=SoftUni2025;TrustServerCertificate=True;",
                b => b.MigrationsAssembly("PropertyManagementSystem.Infrastructure"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}