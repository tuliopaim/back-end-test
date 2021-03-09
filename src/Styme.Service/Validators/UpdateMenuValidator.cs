using FluentValidation;
using Styme.Service.Models.InputModels;

namespace Styme.Service.Validators
{
    public class UpdateMenuValidator : AbstractValidator<UpdateMenuInputModel>
    {
        public UpdateMenuValidator()
        {
            RuleFor(m => m.Id)
                .NotEmpty();

            RuleFor(r => r.Description)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(r => r.Price)
                .GreaterThan(0);

            RuleFor(r => r.Category)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(r => r.ImageUri)
                .Must(uri => (uri?.ToString()?.Length ?? 0) <= 200)
                .WithMessage("The image link cannot have more than 200 caracters");
        }
    }
}
