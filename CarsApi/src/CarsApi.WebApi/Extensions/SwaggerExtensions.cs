using System.Reflection;
using Microsoft.OpenApi.Models;

namespace CarsApi.WebApi.Extensions;

/// <summary>
/// </summary>
public static class SwaggerExtensions
{
    /// <summary>
    ///     Adds full support to swagger open api documentation.
    /// </summary>
    /// <param name="services"></param>
    public static void AddSwaggerDoc(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            // Documentation
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Cars API",
                Version = "v1",
                Description = ""
            });

            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });
    }
}