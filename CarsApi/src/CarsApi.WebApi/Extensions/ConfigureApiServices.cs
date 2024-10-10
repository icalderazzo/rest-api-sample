using CarsApi.Application;
using CarsApi.Infrastructure;

namespace CarsApi.WebApi.Extensions;

/// <summary>
/// </summary>
public static class ConfigureApiServices
{
    /// <summary>
    ///     Sets up DI container.
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddInfrastructureServices();
        services.AddApplicationServices();
    }
}