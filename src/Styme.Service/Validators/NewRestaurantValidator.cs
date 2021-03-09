using FluentValidation;
using Styme.Service.Models.InputModels;

namespace Styme.Service.Validators
{
    public class NewRestaurantValidator : AbstractValidator<NewRestaurantInputModel>
    {
        public NewRestaurantValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(r => r.Address)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(r => r.Category)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(r => r.Location)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(r => r.ImageUri)
                .Must(uri => (uri?.ToString()?.Length ?? 0) <= 200)
                .WithMessage("The image link cannot have more then 200 caracters");
        }
    }
}
