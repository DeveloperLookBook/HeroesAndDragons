using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Extencions
{
    public static class AbstractValidatorExtencion
    {
        public static ModelStateDictionary GetModelStateDictionary<T>(this AbstractValidator<T> validator, T model) where T : class
        {
            if (validator is null) { throw new ArgumentNullException(nameof(validator)); }
            if (model     is null) { throw new ArgumentNullException(nameof(model    )); }

            return validator.Validate(model).ToModelStateDictionary();
        }
    }
}
