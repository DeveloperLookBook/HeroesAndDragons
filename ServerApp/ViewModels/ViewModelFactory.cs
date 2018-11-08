using FluentValidation;
using ServerApp.ViewModels.Dragons;
using ServerApp.ViewModels.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.ViewModels
{
    public interface IViewModelCreator
    {
        DragonViewModel     DragonViewModel    ();
        HeroSigninViewModel HeroSigninViewModel();
        SignupHeroViewModel HeroSignupViewModel();
        HeroViewModel       HeroViewModel      ();
        WeaponViewModel     WeaponViewModel    ();
    }


    public delegate TViewModel ViewModelFactorySelectorFunc<TViewModel>(IViewModelCreator creator)
        where TViewModel : class, IViewModel;


    public static class ViewModelFactory
    {
        private class Creator : IViewModelCreator
        {
            public DragonViewModel     DragonViewModel    () => new DragonViewModel    ();
            public HeroSigninViewModel HeroSigninViewModel() => new HeroSigninViewModel();
            public SignupHeroViewModel HeroSignupViewModel() => new SignupHeroViewModel();
            public HeroViewModel       HeroViewModel      () => new HeroViewModel      ();
            public WeaponViewModel     WeaponViewModel    () => new WeaponViewModel    ();
        }


        static private Creator InstanceCreator => new Creator();


        static public TViewModel Create<TViewModel>(ViewModelFactorySelectorFunc<TViewModel> selector)
            where TViewModel : class, IViewModel
        {
            return selector(InstanceCreator);
        }

        static public TViewModel Create<TViewModel>() where TViewModel : class, IViewModel
        {
            var type = typeof(TViewModel);

            if (type.Equals(typeof(DragonViewModel    ))) return Create(s => s.DragonViewModel    ()) as TViewModel;
            if (type.Equals(typeof(HeroSigninViewModel))) return Create(s => s.HeroSigninViewModel()) as TViewModel;
            if (type.Equals(typeof(SignupHeroViewModel))) return Create(s => s.HeroSignupViewModel()) as TViewModel;
            if (type.Equals(typeof(HeroViewModel      ))) return Create(s => s.HeroViewModel      ()) as TViewModel;
            if (type.Equals(typeof(WeaponViewModel    ))) return Create(s => s.WeaponViewModel    ()) as TViewModel;

            throw new ArgumentException("Selected generic type doesn't exist.");
        }
    }
}
