using AutoMapper;
using CarsApi.Application.DTOs.Car;
using CarsApi.Application.DTOs.Filters;
using CarsApi.Application.Services;
using CarsApi.Domain.Entities;
using CarsApi.Domain.Exceptions;
using CarsApi.Domain.Filters;
using CarsApi.Domain.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace CarsApi.Application.Car;

internal class CarService: ICarService
{
    private readonly IMapper _mapper;
    private readonly IValidator<Domain.Entities.Car> _validator;
    private readonly ICarRepository _carRepository;
    
    public CarService(
        IMapper mapper,
        IValidator<Domain.Entities.Car> validator,
        ICarRepository carRepository)
    {
        _mapper = mapper;
        _validator = validator;
        _carRepository = carRepository;
    }
    
    public GetCarDto Create(CreateCarDto carDto)
    {
        // Map and validate request
        var car = _mapper.Map<Domain.Entities.Car>(carDto);
        Validate(car, "Create");

        // Business logic
        if (_carRepository.Exists(car)) throw new EntityAlreadyExistsException($"The car with vin {car.Vin} or plate number {car.PlateNumber} already exists");
        
        // Transaction
        _carRepository.Create(car);
        
        // Respond with mapped entity
        return _mapper.Map<GetCarDto>(car);
    }

    public GetCarDto Update(long vin, CarDto carDto)
    {
        // Validate if entity exists
        if (!_carRepository.Exists(vin)) throw new EntityNotFoundException($"The car with vin {vin} does not exists");
        
        // Validate received data
        var newCarData = _mapper.Map<Domain.Entities.Car>(carDto);
        Validate(newCarData);
        
        // Transaction
        var updatedCar = _carRepository.Update(vin, newCarData);
        
        // Respond with mapped entity
        return _mapper.Map<GetCarDto>(updatedCar);
    }
    
    public GetCarDto GetByVin(long vin)
    {
        var car = _carRepository.GetByVin(vin);
        if (car is null) throw new EntityNotFoundException($"The car with vin {vin} does not exists");
        
        // Respond with mapped entity
        return _mapper.Map<GetCarDto>(car);
    }

    public List<GetCarDto> Get(CarsSearchFilterDto filter)
    {
        // If filter has no search filters return all entities
        if(!filter.HasAny()) return _mapper.Map<List<GetCarDto>>(_carRepository.GetAll());
        
        // Map to domain filter and return filtered list
        var searchFilter = _mapper.Map<CarsSearchFilter>(filter);
        return _mapper.Map<List<GetCarDto>>(_carRepository.Get(searchFilter));
    }
    
    public void Delete(long vin)
    {
        // Validate if entity exists
        if(!_carRepository.Exists(vin)) throw new EntityNotFoundException($"The car with vin {vin} does not exists");
        
        // Business logic if necessary
        
        // Transaction
        _carRepository.Delete(vin);
    }

    public GetServiceDto CreateService(long vin, ServiceDto serviceDto)
    {
        // Validate if entity exists
        if(!_carRepository.Exists(vin)) throw new EntityNotFoundException($"The car with vin {vin} does not exists");
        
        // Transaction
        var service = _mapper.Map<Service>(serviceDto);
        _carRepository.AddService(vin, service);
        
        // Respond with mapped entity
        return _mapper.Map<GetServiceDto>(service);
    }

    private void Validate(Domain.Entities.Car car, string? validationRuleSet = null)
    {
        ValidationResult? validationResult;
        
        if (string.IsNullOrEmpty(validationRuleSet))
            validationResult = _validator.Validate(car);
        else
            validationResult = _validator.Validate(car, options: opt =>
            {
                opt.IncludeRulesNotInRuleSet();
                opt.IncludeRuleSets(validationRuleSet);
            });
        
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);
    }
}