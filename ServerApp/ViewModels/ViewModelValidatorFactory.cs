using FluentValidation;
using ServerApp.ViewModels.Heroes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.ViewModels
{
    public interface IViewModelValidatorCreator
    {
        SignupHeroViewModelValidator SignupHeroViewModelValidator();
    }


    public delegate TViewModelValidator ViewModelValidatorFactorySelectorFunc<TViewModelValidator>(IViewModelValidatorCreator creator)
        where TViewModelValidator : IValidator;


    public static class ViewModelValidatorFactory
    {
        private class Creator : IViewModelValidatorCreator
        {
            public SignupHeroViewModelValidator SignupHeroViewModelValidator() => new SignupHeroViewModelValidator();
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

            if (type.Equals(typeof(SignupHeroViewModelValidator))) return Create(s => s.SignupHeroViewModelValidator()) as IValidator<TViewModel>;

            throw new ArgumentException("Selected generic type doesn't exist.");
        }
    }    
}
