namespace CarsApi.Application.DTOs.Car;

public class CreateCarDto: CarDto
{
    /// <summary>
    ///     The Vehicle Identification Number (VIN) of the car
    /// </summary>
    public long Vin { get; set; }
    
    /// <summary>
    ///     The plate number of the car.
    /// </summary>
    public string PlateNumber { get; set; }
}