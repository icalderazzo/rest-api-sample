using CarsApi.Domain.Entities;
using CarsApi.Domain.Filters;

namespace CarsApi.Domain.Repositories;

public interface ICarRepository
{
    void Create(Car car);
    
    Car Update(long vin, Car car);
    
    Car? GetByVin(long vin);
    
    List<Car> Get(CarsSearchFilter filter);
    
    List<Car> GetAll();
    
    void Delete(long vin);
    
    void AddService(long vin, Service service);
    
    bool Exists(Car car);
    
    bool Exists(long vin);
}