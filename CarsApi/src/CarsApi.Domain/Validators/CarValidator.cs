using FluentValidation;

namespace CarsApi.Domain.Validators;

public class CarValidator: AbstractValidator<Entities.Car>
{
    public CarValidator()
    {
        RuleFor(c => c.Brand).NotEmpty().WithMessage("Brand is required");
        
        RuleFor(c => c.Model).NotEmpty().WithMessage("Model is required");
        
        RuleSet("Create", () =>
        {
            RuleFor(c => c.Vin)
                .NotEmpty().WithMessage("Vin is required")
                .GreaterThan(0).WithMessage("Vin must be greater than 0");
            
            RuleFor(c => c.PlateNumber).NotEmpty().WithMessage("Plate number is required");
        });
    }
}