using FluentValidation;
using Homework20.Domain;

namespace Homework20.Validations;

public class AdressValidations : AbstractValidator<Adress>
{
    public AdressValidations()
    {
        RuleFor(adress => adress.City).NotEmpty().WithMessage("City cannot be empty");
        RuleFor(adress => adress.Country).NotEmpty().WithMessage("Country cannot be empty");
        RuleFor(adress => adress.HomeNumber).NotEmpty().WithMessage("Home number cannot be empty");
    }
}