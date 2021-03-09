using FluentValidation;
using Styme.Service.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styme.Service.Validators
{
    class UpdateRestaurantValidator : AbstractValidator<UpdateRestaurantInputModel>
    {
        public UpdateRestaurantValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty();

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
