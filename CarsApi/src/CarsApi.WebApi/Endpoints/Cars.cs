using CarsApi.Application.DTOs;
using CarsApi.Application.DTOs.Car;
using CarsApi.Application.DTOs.Filters;
using CarsApi.Application.Services;
using CarsApi.Domain.Exceptions;
using CarsApi.WebApi.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.WebApi.Endpoints;

/// <summary>
/// </summary>
public static class Cars
{
    /// <summary>
    ///     Creates a new car  
    /// </summary>
    /// <returns></returns>
    /// <response code="201">The car was successfully created</response>
    /// <response code="409">A car is already registered with the same VIN or Plate number</response>
    public static IResult Create(ICarService carService, CreateCarDto carDto)
    {
        try
        {
            var result = carService.Create(carDto);
            return Results.Created("api/cars", result);
        }
        catch (ValidationException ex) { return ex.ToProblemDetails(); }
        catch (EntityAlreadyExistsException ex) { return ex.ToProblemDetails(); }
    }

    /// <summary>
    ///     Updates an existing car  
    /// </summary>
    /// <param name="carService"></param>
    /// <param name="vin">The VIN of the car to update</param>
    /// <param name="carDto"></param>
    /// <returns></returns>
    /// <response code="200">The car was successfully updated</response>
    /// <response code="400">Validation errors</response>
    /// <response code="404">The car with the specified VIN does not exist</response>
    public static IResult Update(ICarService carService, [FromRoute] long vin, CarDto carDto)
    {
        try
        {
            var result = carService.Update(vin, carDto);
            return Results.Ok(result); 
        }
        catch (ValidationException ex) { return ex.ToProblemDetails(); }
        catch (EntityNotFoundException ex) { return ex.ToProblemDetails(); }
    }

    /// <summary>
    ///     Gets a car by its VIN
    /// </summary>
    /// <param name="carService"></param>
    /// <param name="vin">The VIN of the car to get</param>
    /// <returns></returns>
    /// <response code="200">The car with the specified VIN was found</response>
    /// <response code="404">The car with the specified VIN does not exist</response>
    public static IResult GetByVin(ICarService carService, [FromRoute] long vin)
    {
        try
        {
            var result = carService.GetByVin(vin);
            return Results.Ok(result);
        }
        catch (EntityNotFoundException ex) { return ex.ToProblemDetails(); }
    }

    /// <summary>
    ///     Gets a list of cars. If no filter is provided, all the cars in the system will be returned.
    /// </summary>
    /// <returns></returns>
    /// <response code="200">The list of cars was retrieved successfully</response>
    public static IResult Get(ICarService carService, [AsParameters] CarsSearchFilterDto searchFilter)
    {
        var result = carService.Get(searchFilter);
        return Results.Ok(result);
    }

    /// <summary>
    ///     Deletes a car
    /// </summary>
    /// <param name="carService"></param>
    /// <param name="vin">The VIN of the car to delete</param>
    /// <returns></returns>
    /// <response code="204">The car was successfully deleted</response>
    /// <response code="404">The car with the specified VIN does not exist</response>
    public static IResult Delete(ICarService carService, [FromRoute] long vin)
    {
        try
        {
            carService.Delete(vin);
            return Results.NoContent();
        }
        catch (EntityNotFoundException ex) { return ex.ToProblemDetails(); }
    }

    /// <summary>
    ///     Adds a service to a car
    /// </summary>
    /// <param name="carService"></param>
    /// <param name="vin">The VIN of the car that received the service</param>
    /// <param name="serviceDto">The mechanic's description of the work done</param>
    /// <response code="201">The service was successfully added to the car</response>
    /// <response code="404">The car with the specified VIN does not exist</response>
    public static IResult AddService(ICarService carService, [FromRoute] long vin, ServiceDto serviceDto)
    {
        try
        {
            var result = carService.CreateService(vin, serviceDto);
            return Results.Created($"api/cars/{vin}/services", result);
        }
        catch (EntityNotFoundException ex) { return ex.ToProblemDetails(); }
    }
}