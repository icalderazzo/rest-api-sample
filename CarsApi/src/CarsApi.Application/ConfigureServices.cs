using System.Reflection;
using CarsApi.Application.Car;
using CarsApi.Application.Services;
using CarsApi.Domain.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CarsApi.Application;

public static class ConfigureServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        // Services
        services.AddScoped<ICarService, CarService>();
        
        // Validators
        services.AddScoped<IValidator<Domain.Entities.Car>, CarValidator>();
        
        // AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}