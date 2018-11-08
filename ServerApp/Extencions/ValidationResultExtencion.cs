using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ServerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Extencions
{
    public static class ValidationResultExtencion
    {
        public static ModelStateDictionary ToModelStateDictionary(this ValidationResult value)
        {
            return ModelStateDictionaryFactory.Create(value);
        }
    }
}
