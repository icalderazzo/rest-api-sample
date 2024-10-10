using CarsApi.Domain.Exceptions;
using FluentValidation;

namespace CarsApi.WebApi.Extensions;

/// <summary>
/// </summary>
public static class ExceptionsExtensions
{
    /// <summary>
    ///     Handles ValidationException and returns 400 with problem details format.
    /// </summary>
    /// <param name="exception">A ValidationException instance.</param>
    /// <returns></returns>
    public static IResult ToProblemDetails(this ValidationException exception)
    {
        var errors = new Dictionary<string, dynamic?>();
        foreach (var validationFailure in exception.Errors)
        {
            errors[validationFailure.PropertyName.ToLower()] = validationFailure.ErrorMessage.Split(',');
        }

        return Results.Problem(
            statusCode: StatusCodes.Status400BadRequest, 
            title: "Validation Failed",
            detail: "One or more validation errors occurred",
            extensions: errors);
    }
    
    /// <summary>
    ///     Handles EntityAlreadyExistsException and returns 409 with problem details format.
    /// </summary>
    /// <param name="exception">An EntityAlreadyExistsException instance.</param>
    /// <returns></returns>
    public static IResult ToProblemDetails(this EntityAlreadyExistsException exception)
    {
        return Results.Problem(
            statusCode: StatusCodes.Status409Conflict, 
            title: "Resource already exists",
            detail: exception.Message);
    }
    
    /// <summary>
    ///     Handles EntityNotFoundException and returns 404 with problem details format.
    /// </summary>
    /// <param name="exception">An EntityNotFoundException instance.</param>
    /// <returns></returns>
    public static IResult ToProblemDetails(this EntityNotFoundException exception)
    {
        return Results.Problem(
            statusCode: StatusCodes.Status404NotFound, 
            title: "Resource not found",
            detail: exception.Message);
    }
}