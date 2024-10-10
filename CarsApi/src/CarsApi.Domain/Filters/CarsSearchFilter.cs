namespace CarsApi.Domain.Filters;

public class CarsSearchFilter
{
    public string? PlateNumber { get; set; }
    
    public string? Brand { get; set; }
    
    public string? Model { get; set; }
}