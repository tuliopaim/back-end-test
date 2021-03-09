using FluentValidation.Results;
using Styme.Service.Interfaces;
using Styme.Service.Validators;
using System;

namespace Styme.Service.Models.InputModels
{
    public class NewRestaurantInputModel : IInputModel
    {
        private readonly NewRestaurantValidator _validator;

        public NewRestaurantInputModel()
        {
            _validator = new NewRestaurantValidator();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public Uri ImageUri { get; set; }

        public bool ItsValid => ValidationResult.IsValid;

        public ValidationResult ValidationResult => _validator.Validate(this);
    }
}
