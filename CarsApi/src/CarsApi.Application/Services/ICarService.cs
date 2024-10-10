using CarsApi.Application.DTOs;
using CarsApi.Application.DTOs.Car;
using CarsApi.Application.DTOs.Filters;

namespace CarsApi.Application.Services;

public interface ICarService
{
    GetCarDto Create(CreateCarDto carDto);
    
    GetCarDto Update(long vin, CarDto carDto);
    
    GetCarDto GetByVin(long vin);
    
    List<GetCarDto> Get(CarsSearchFilterDto filter);
    
    void Delete(long vin);
    
    GetServiceDto CreateService(long vin, ServiceDto serviceDto);
}