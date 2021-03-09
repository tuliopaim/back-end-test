using FluentValidation.Results;

namespace Styme.Service.Interfaces
{
    public interface IValidationModel
    {
        ValidationResult ValidationResult { get; }

        bool IsValid { get; }
    }
}
