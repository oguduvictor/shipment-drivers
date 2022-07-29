using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Protium.Digital.Data.Sql.InMemory.Repositories;
using Protium.Digital.Data.Sql.InMemory.Seeds;
using Protium.Digital.Domain.Interfaces.Repositories;

namespace Protium.Digital.Data.Sql.InMemory;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqlInMemoryLayer(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(builder =>
        {
            builder.UseInMemoryDatabase("protium");
        });

        services.AddScoped<IDriverRepository, DriverRepository>();
        services.AddScoped<IShipmentRepository, ShipmentRepository>();

        return services;
    }

    public static void SeedDatabase(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var shouldSave = false;

            if (!dbContext.Drivers.Any())
            {
                dbContext.Drivers.AddRange(DriverSeedData.Get);
                shouldSave = true;
            }

            if (!dbContext.Shipments.Any())
            {
                dbContext.Shipments.AddRange(ShipmentSeedData.Get);
                shouldSave = true;
            }

            if (shouldSave)
            {
                dbContext.SaveChanges();
            }
        }
    }
}