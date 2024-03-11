using clinicpro.Entities;
using FluentValidation;

namespace clinicpro.Validators;

public class PatientValidator : AbstractValidator<Patient>
{
    public PatientValidator()
    {
        RuleFor(p => p.firstName).NotNull();
        RuleFor(p => p.lastName).NotNull();
        RuleFor(p => p.gender).NotNull();
        RuleFor(p => p.dateOfBirth).NotEmpty().WithMessage("Date of birth is required")
            .Must(ValidDate).WithMessage("Invalid date of birth");
        RuleFor(p => p.height).NotEmpty().GreaterThan(0);
        RuleFor(p => p.weight).NotEmpty().GreaterThan(0);
        RuleFor(p => p.email).NotEmpty();
    }

    private bool ValidDate(DateTime date)
    {
        return date < DateTime.Today && date > new DateTime(1900, 1, 1);
    }
}