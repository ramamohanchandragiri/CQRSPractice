using FluentValidation;
using SampleProject.Application.Features.Product.Commands;

namespace SampleProject.Application.Validators
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!")
               .Length(2, 8)
               .Must(IsValidName).WithMessage("{PropertyName} should be all letters.");
        }

        private bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}
