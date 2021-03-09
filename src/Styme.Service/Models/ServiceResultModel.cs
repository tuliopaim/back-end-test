using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Styme.Service.Models
{
    public class ServiceResultModel
    {
        private ServiceResultModel()
        {
        }

        public ServiceResultModel(ValidationResult results)
        {
            Valid = results.IsValid;

            Errors = results.Errors?.Select(e => $"[{e.PropertyName}] - {e.ErrorMessage}").ToList();
        }

        public object Data { get; set; }

        public string Message { get; set; }

        public bool Valid { get; set; }

        public List<string> Errors { get; set; }

        public static ServiceResultModel Success (object data = null, string message = null)
        {
            return new ServiceResultModel
            {
                Data = data,
                Message = message,
                Valid = true
            };
        }

        public static ServiceResultModel Error(string message = null, List<string> errors = null)
        {
            errors ??= !string.IsNullOrWhiteSpace(message)
                ? new List<string> { message }
                : new List<string>();

            return new ServiceResultModel
            {
                Message = message,
                Valid = false,
                Errors = errors
            };
        }
    }
}
