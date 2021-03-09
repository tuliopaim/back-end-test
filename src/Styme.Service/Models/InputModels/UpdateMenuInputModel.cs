using FluentValidation.Results;
using Styme.Service.Interfaces;
using Styme.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Styme.Service.Models.InputModels
{
    public class UpdateMenuInputModel : IInputModel
    {
        private readonly UpdateMenuValidator _validator;

        public UpdateMenuInputModel()
        {
            _validator = new UpdateMenuValidator();
        }

        public long Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Uri ImageUri { get; set; }
        public string Category { get; set; }

        [JsonIgnore]
        public ValidationResult ValidationResult => _validator.Validate(this);

        [JsonIgnore]
        public bool IsValid => ValidationResult.IsValid;
    }
}
