using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data
{
    public static class ModelStateDictionaryFactory
    {
        static public ModelStateDictionary Create()
        {
            return new ModelStateDictionary();
        }        
        static public ModelStateDictionary Create(ValidationResult value)
        {
            if (value is null) { throw new ArgumentNullException(nameof(value)); }

            var state = Create();

            foreach (var e in value.Errors)
            {
                state.AddModelError(e.PropertyName, e.ErrorMessage);
            }

            return state;
        }
    }
}
