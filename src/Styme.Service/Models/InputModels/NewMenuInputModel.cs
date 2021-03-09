using FluentValidation.Results;
using Styme.Service.Interfaces;
using Styme.Service.Validators;
using System;

namespace Styme.Service.Models.InputModels
{
    public class NewMenuInputModel : IInputModel
    {
        private readonly NewMenuValidator _validator;

        public NewMenuInputModel()
        {
            _validator = new NewMenuValidator();
        }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public Uri ImageUri { get; set; }
        public string Category { get; set; }
        public long RestaurantId { get; set; }

        public ValidationResult ValidationResult => _validator.Validate(this);

        public bool ItsValid => ValidationResult.IsValid;
    }
}
