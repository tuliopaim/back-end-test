using FluentValidation.Results;

namespace Styme.Service.Interfaces
{
    public interface IInputModel
    {
        ValidationResult ValidationResult { get; }

        bool IsValid { get; }
    }
}
