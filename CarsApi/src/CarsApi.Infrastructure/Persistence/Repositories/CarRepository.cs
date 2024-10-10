using CarsApi.Domain.Entities;
using CarsApi.Domain.Filters;
using CarsApi.Domain.Repositories;

namespace CarsApi.Infrastructure.Persistence.Repositories;

internal class CarRepository : ICarRepository
{
    public void Create(Car car)
    {
        car.CreatedAt = DateTime.UtcNow;
        MockDb.Cars.Add(car);
    }

    public Car Update(long vin, Car car)
    {
        var updateCar = MockDb.Cars.FirstOrDefault(c => c.Vin.Equals(vin));

        updateCar!.Brand = car.Brand;
        updateCar.Model = car.Model;
        
        return updateCar;
    }

    public Car? GetByVin(long vin)
    {
        return MockDb.Cars.FirstOrDefault(c => c.Vin.Equals(vin));
    }

    public List<Car> Get(CarsSearchFilter filter)
    {
        var query = MockDb.Cars.AsQueryable();
        
        if(filter.PlateNumber is not null) query = query.Where(c => c.PlateNumber.Contains(filter.PlateNumber));
        if(filter.Brand is not null) query = query.Where(c => c.Brand.Contains(filter.Brand));
        if(filter.Model is not null) query = query.Where(c => c.Model.Contains(filter.Model));
        
        return query.ToList()!;
    }

    public List<Car> GetAll()
    {
        return MockDb.Cars.ToList()!;
    }

    public void Delete(long vin)
    {
        var deleteCar = MockDb.Cars.FirstOrDefault(c => c.Vin.Equals(vin));
        MockDb.Cars.Remove(deleteCar);
    }

    public void AddService(long vin, Service service)
    {
        var car = MockDb.Cars.FirstOrDefault(c => c.Vin.Equals(vin));
        if(car!.Services is null) car.Services = [];
        
        service.Id = Guid.NewGuid();
        service.Date = DateTime.UtcNow;
        
        car.Services.Add(service);
    }

    public bool Exists(Car car)
    {
        return MockDb.Cars.Any(c => c.Vin.Equals(car.Vin) || c.Brand.Equals(car.PlateNumber));
    }

    public bool Exists(long vin)
    {
        return MockDb.Cars.Any(c => c.Vin.Equals(vin));
    }
}