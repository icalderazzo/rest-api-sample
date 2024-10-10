namespace CarsApi.Domain.Entities;

public class Car
{
    public long Vin { get; set; }
    
    public string PlateNumber { get; set; }
    
    public string Brand { get; set; }
    
    public string Model { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<Service>? Services { get; set; }
}