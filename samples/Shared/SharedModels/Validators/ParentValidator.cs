using FluentValidation;
using JetBrains.Annotations;

namespace SharedModels.Validators;

[UsedImplicitly]
public class ParentValidator : AbstractValidator<Parent>
{
    public ParentValidator()
    {
        RuleForEach(p => p.Children).SetValidator(new ChildValidator());
    }
}