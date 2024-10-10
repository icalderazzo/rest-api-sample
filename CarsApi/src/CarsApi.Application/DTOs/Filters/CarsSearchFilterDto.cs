using Microsoft.AspNetCore.Mvc;

namespace CarsApi.Application.DTOs.Filters;

public class CarsSearchFilterDto
{
    [FromQuery(Name = "plateNumber")]
    public string? PlateNumber { get; set; }
    
    [FromQuery(Name = "brand")]
    public string? Brand { get; set; }
    
    [FromQuery(Name = "model")]
    public string? Model { get; set; }

    public bool HasAny()
    {
        return !string.IsNullOrEmpty(PlateNumber) || !string.IsNullOrEmpty(Brand) || !string.IsNullOrEmpty(Model);
    }
}