﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Styme.Service.Models.Results
{
    public class ServiceResult
    {
        private ServiceResult()
        {
        }

        public ServiceResult(ValidationResult results)
        {
            Success = results.IsValid;

            Errors = results.Errors?.Select(e => $"[{e.PropertyName}] - {e.ErrorMessage}").ToList();
        }

        public ServiceResult(Exception exception)
        {
            Success = false;
            Message = $"Ocorreu um erro: {exception.Message}";
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Data { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> Errors { get; set; }

        public bool Success { get; set; }

        public static ServiceResult SuccessResult (object data = null, string message = null)
        {
            return new ServiceResult
            {
                Data = data,
                Message = message,
                Success = true
            };
        }

        public static ServiceResult ErrorResult(string message = null, List<string> errors = null)
        {
            errors ??= !string.IsNullOrWhiteSpace(message)
                ? new List<string> { message }
                : new List<string>();

            return new ServiceResult
            {
                Message = message,
                Success = false,
                Errors = errors
            };
        }
    }
}
