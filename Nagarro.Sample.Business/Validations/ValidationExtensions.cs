using FluentValidation.Results;
using Nagarro.Sample.Shared;
using System.Collections.Generic;

namespace Nagarro.Sample.Validations
{
    public static class ValidationExtensions
    {
        public static NagarroSampleValidationResult ToValidationResult(this ValidationResult result)
        {
            IList<NagarroSampleValidationFailure> errors = new List<NagarroSampleValidationFailure>();

            foreach (ValidationFailure failure in result.Errors)
            {
                errors.Add(failure.ToValidationFailure());
            }

            return new NagarroSampleValidationResult(errors);
        }

        public static NagarroSampleValidationFailure ToValidationFailure(this ValidationFailure failure)
        {
            return new NagarroSampleValidationFailure(failure.PropertyName, failure.ErrorMessage, failure.AttemptedValue);
        }
        
    }
}
