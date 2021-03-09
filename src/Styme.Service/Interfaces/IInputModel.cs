using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styme.Service.Interfaces
{
    public interface IInputModel
    {
        public ValidationResult ValidationResult { get; }
        public bool ItsValid { get; }
    }
}
