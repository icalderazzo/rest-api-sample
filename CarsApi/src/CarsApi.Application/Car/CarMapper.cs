using AutoMapper;
using CarsApi.Application.DTOs;
using CarsApi.Application.DTOs.Car;
using CarsApi.Application.DTOs.Filters;
using CarsApi.Domain.Entities;
using CarsApi.Domain.Filters;

namespace CarsApi.Application.Car;

internal class CarMapper : Profile
{
    public CarMapper()
    {
        // Models
        CreateMap<CarDto, Domain.Entities.Car>();
        CreateMap<CreateCarDto, Domain.Entities.Car>().IncludeBase<CarDto, Domain.Entities.Car>();
        CreateMap<Domain.Entities.Car, GetCarDto>();
        CreateMap<ServiceDto, Service>();
        CreateMap<Service, GetServiceDto>();
        
        // Filters
        CreateMap<CarsSearchFilterDto, CarsSearchFilter>();
    }
}