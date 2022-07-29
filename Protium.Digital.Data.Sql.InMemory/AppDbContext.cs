using Microsoft.EntityFrameworkCore;
using Protium.Digital.Domain.Entities;

namespace Protium.Digital.Data.Sql.InMemory;

internal class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base (options)
    {
    }

    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Shipment> Shipments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }

        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseInMemoryDatabase("protium");
        // optionsBuilder.UseSqlite("DataSource:protium.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}