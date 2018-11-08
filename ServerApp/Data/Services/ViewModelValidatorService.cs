using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ServerApp.Data.Mediators;
using ServerApp.ViewModels;
using ServerApp.Extencions;

namespace ServerApp.Data.Services
{
    public class ViewModelValidatorService : Service
    {
        public ViewModelValidatorService(Mediator mediator) : base(mediator)
        {
        }

        public bool Validate<TViewModel>(TViewModel viewModel, out ModelStateDictionary state) where TViewModel: class, IViewModel
        {
            var validator        = ViewModelValidatorFactory.Create<TViewModel>();
            var validationResult = validator.Validate(viewModel);
            
            state = validationResult.ToModelStateDictionary();

            return validationResult.IsValid;
        }
    }
}
