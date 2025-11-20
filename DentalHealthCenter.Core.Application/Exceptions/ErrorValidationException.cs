
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace DentalHealthCenter.Core.Application.Exceptions
{
    public class ErrorValidationException : Exception
    {
        public List<string> Errors { get; set; } = new();

        public ErrorValidationException(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}
