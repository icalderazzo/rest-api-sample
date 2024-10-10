using CarsApi.Domain.Repositories;
using CarsApi.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CarsApi.Infrastructure;

public static class ConfigureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        // Services
        services.AddScoped<ICarRepository, CarRepository>();
    }
}