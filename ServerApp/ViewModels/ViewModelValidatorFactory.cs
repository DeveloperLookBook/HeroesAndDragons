using FluentValidation;
using ServerApp.ViewModels.Characters.Heroes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.ViewModels
{
    public interface IViewModelValidatorCreator
    {
        CreateHeroViewModelValidator CreateHeroViewModelValidator();
    }


    public delegate TViewModelValidator ViewModelValidatorFactorySelectorFunc<TViewModelValidator>(IViewModelValidatorCreator creator)
        where TViewModelValidator : IValidator;


    public static class ViewModelValidatorFactory
    {
        private class Creator : IViewModelValidatorCreator
        {
            public CreateHeroViewModelValidator CreateHeroViewModelValidator() => new CreateHeroViewModelValidator();
        }


        static private Creator InstanceCreator => new Creator();


        static public TViewModelValidator Create<TViewModelValidator>(ViewModelValidatorFactorySelectorFunc<TViewModelValidator> selector) 
            where TViewModelValidator : class, IValidator
        {
            return selector(InstanceCreator);
        }        

        static public IValidator<TViewModel> Create<TViewModel>() where TViewModel : class,IViewModel
        {
            var type = typeof(TViewModel);

            if (type.Equals(typeof(CreateHeroViewModelValidator))) return Create(s => s.CreateHeroViewModelValidator()) as IValidator<TViewModel>;

            throw new ArgumentException("Selected generic type doesn't exist.");
        }
    }    
}
