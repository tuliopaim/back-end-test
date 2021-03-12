using FluentValidation.Results;
using Styme.Domain.Interfaces;
using Styme.Service.Validators;
using System;
using System.Text.Json.Serialization;

namespace Styme.Service.Models.InputModels
{
    public class NewMenuInputModel : IValidationModel<NewMenuInputModel>
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

        [JsonIgnore]
        public ValidationResult ValidationResult => _validator.Validate(this);

        [JsonIgnore]
        public bool IsValid => ValidationResult.IsValid;
    }
}
