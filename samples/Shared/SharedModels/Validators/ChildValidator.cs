using FluentValidation;

namespace SharedModels.Validators;

public class ChildValidator : AbstractValidator<Child>
{
    public ChildValidator()
    {
        RuleFor(p => p.FirstName).NotEmpty().WithMessage("You must enter your first name");
    }
}