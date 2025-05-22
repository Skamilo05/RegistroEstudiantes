using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Infrastructure.Data;

namespace Infrastructure.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(
            "Server=DESKTOP-JKS0JRC;Database=registrodb;User Id=Camilo;Password=12345678;TrustServerCertificate=True;");

        return new AppDbContext(optionsBuilder.Options);
    }
}
