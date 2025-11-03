using System.Data;
using FluentValidation;
using Homework16.Model;

namespace Homework16.Validations;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(person => person.CreateDate).NotEmpty().WithMessage("create date cannot be empty")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("create date cannot be greater than today");
        
        RuleFor(person => person.FirstName).NotEmpty().WithMessage("First name cannot be empty")
            .MaximumLength(50).WithMessage("First name cannot be longer than 50 characters");
        RuleFor(person => person.LastName).NotEmpty().WithMessage("last name cannot be empty")
            .MaximumLength(50).WithMessage("last name cannot be longer than 50 characters");
        RuleFor(person => person.JobPosition).NotEmpty().WithMessage("job position cannot be empty")
            .MaximumLength(50).WithMessage("job position cannot be longer than 50 characters");
        
        RuleFor(person => person.Salary).NotEmpty().WithMessage("salary cannot be empty")
            .GreaterThanOrEqualTo(0).WithMessage("salary cannot be lesser than 0")
            .LessThanOrEqualTo(10000).WithMessage("salary cannot be greater than 10000");

        RuleFor(person => person.WorkExperience).NotEmpty().WithMessage("work experience cannot be empty");
        RuleFor(person => person.PersonAdress).SetValidator(new AdressValidator());
        
    }
}