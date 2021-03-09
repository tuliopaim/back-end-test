using FluentValidation.Results;
using Styme.Service.Interfaces;
using Styme.Service.Validators;
using System;
using System.Text.Json.Serialization;

namespace Styme.Service.Models.InputModels
{
    public class UpdateRestaurantInputModel : IInputModel
    {
        private readonly UpdateRestaurantValidator _validator;

        public UpdateRestaurantInputModel()
        {
            _validator = new UpdateRestaurantValidator();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public Uri ImageUri { get; set; }

        [JsonIgnore]
        public ValidationResult ValidationResult => _validator.Validate(this);

        [JsonIgnore]
        public bool IsValid => ValidationResult.IsValid;
    }
}
