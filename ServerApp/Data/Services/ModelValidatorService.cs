using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ServerApp.Data.Mediators;
using ServerApp.Models;
using ServerApp.Extencions;

namespace ServerApp.Data.Services
{
    public class ModelValidatorService : Service
    {
        public ModelValidatorService(Mediator mediator) : base(mediator)
        {
        }

        public bool Validate<TModel>(TModel viewModel, out ModelStateDictionary state) where TModel : class, IModel
        {
            var validator        = ModelValidatorFactory.Create<TModel>();
            var validationResult = validator.Validate(viewModel);

            state = validationResult.ToModelStateDictionary();

            return validationResult.IsValid;
        }
    }
}
