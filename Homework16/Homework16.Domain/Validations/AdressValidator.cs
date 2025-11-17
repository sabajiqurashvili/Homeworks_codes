using FluentValidation;
using Homework16.Model;

namespace Homework16.Validations;

public class AdressValidator : AbstractValidator<Adress>
{
    public AdressValidator()
    {
        RuleFor(adress => adress.City).NotEmpty().WithMessage("City cannot be empty");
        RuleFor(adress => adress.Country).NotEmpty().WithMessage("Country cannot be empty");
        RuleFor(adress => adress.HomeNumber).NotEmpty().WithMessage("Home number cannot be empty");
    }
}