namespace CarsApi.Application.DTOs.Car;

public class GetCarDto: CarDto
{
    /// <summary>
    ///     The Vehicle Identification Number (VIN) of the car
    /// </summary>
    public long Vin { get; set; }
    
    /// <summary>
    ///     The plate number of the car.
    /// </summary>
    public string PlateNumber { get; set; }

    /// <summary>
    ///     The date and time the car was created in the system in UTC.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///     The services the car has received.
    /// </summary>
    public List<GetServiceDto> Services { get; set; }
}