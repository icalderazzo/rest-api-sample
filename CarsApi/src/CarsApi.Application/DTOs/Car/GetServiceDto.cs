namespace CarsApi.Application.DTOs.Car;

public class GetServiceDto: ServiceDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
}