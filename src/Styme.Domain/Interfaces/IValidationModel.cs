using FluentValidation.Results;

namespace Styme.Domain.Interfaces
{
    public interface IValidationModel<T> : Model<IValidationModel<T>>
    {
        ValidationResult ValidationResult { get; }

        bool IsValid { get; }
    }

    public interface Model<T>
    {

    }
}
