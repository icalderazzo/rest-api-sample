using CarsApi.WebApi.Endpoints;
using CarsApi.WebApi.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerDoc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureServices();

var app = builder.Build();

app.UseExceptionHandler(appError =>
{
    appError.Run(async ctx =>
    {
        ctx.Response.StatusCode = StatusCodes.Status500InternalServerError;
        ctx.Response.ContentType = "application/json";
        
        var contextFeature = ctx.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature is not null)
        {
            await ctx.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal Server Error",
                Detail = "Unexpected error occured.",
            });
        }
    });
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt => { opt.DefaultModelsExpandDepth(-1); });
}

// Health
app.MapGet("/", () => "Welcome to Cars API!");
// Cars API
var carsApi = app.MapGroup("api/cars");
carsApi.MapPost(string.Empty, Cars.Create);
carsApi.MapPost("{vin:long}/services", Cars.AddService);
carsApi.MapGet(string.Empty, Cars.Get);
carsApi.MapGet("{vin:long}", Cars.GetByVin);
carsApi.MapPut("{vin:long}", Cars.Update);
carsApi.MapDelete("{vin:long}", Cars.Delete);

app.Run();