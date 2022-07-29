using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Protium.Digital.Data.Sql.InMemory;

internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.EnableSensitiveDataLogging();

        // optionsBuilder.UseSqlite("DataSource:protium.db");
        optionsBuilder.UseInMemoryDatabase("protium");
        return new AppDbContext(optionsBuilder.Options);
    }
}