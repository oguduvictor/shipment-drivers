using Microsoft.Extensions.DependencyInjection;
using Protium.Digital.Domain.Interfaces.Services;

namespace Protium.Digital.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServiceLayer(this IServiceCollection services)
    {
        services.AddScoped<IDriverService, DriverService>();
        services.AddScoped<IShipmentService, ShipmentService>();

        return services;
    }
}