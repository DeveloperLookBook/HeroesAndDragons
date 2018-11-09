using FluentValidation;
using ServerApp.ViewModels.Characters.Dragons;
using ServerApp.ViewModels.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.ViewModels
{
    public interface IViewModelCreator
    {
        DragonViewModel           DragonViewModel          ();
        CreateHeroViewModel       CreateHeroViewModel      ();
        SigninHeroViewModel       SigninHeroViewModel      ();
        HeroViewModel             HeroViewModel            ();
        WeaponViewModel           WeaponViewModel          ();
        ReadHeroesByNameViewModel ReadHeroesByNameViewModel();
    }


    public delegate TViewModel ViewModelFactorySelectorFunc<TViewModel>(IViewModelCreator creator)
        where TViewModel : class, IViewModel;


    public static class ViewModelFactory
    {
        private class Creator : IViewModelCreator
        {
            public DragonViewModel           DragonViewModel          () => new DragonViewModel          ();
            public CreateHeroViewModel       CreateHeroViewModel      () => new CreateHeroViewModel      ();
            public SigninHeroViewModel       SigninHeroViewModel      () => new SigninHeroViewModel      ();
            public HeroViewModel             HeroViewModel            () => new HeroViewModel            ();
            public WeaponViewModel           WeaponViewModel          () => new WeaponViewModel          ();
            public ReadHeroesByNameViewModel ReadHeroesByNameViewModel() => new ReadHeroesByNameViewModel();
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

            if (type.Equals(typeof(DragonViewModel          ))) return Create(s => s.DragonViewModel          ()) as TViewModel;
            if (type.Equals(typeof(CreateHeroViewModel      ))) return Create(s => s.CreateHeroViewModel      ()) as TViewModel;
            if (type.Equals(typeof(SigninHeroViewModel      ))) return Create(s => s.SigninHeroViewModel      ()) as TViewModel;
            if (type.Equals(typeof(HeroViewModel            ))) return Create(s => s.HeroViewModel            ()) as TViewModel;
            if (type.Equals(typeof(WeaponViewModel          ))) return Create(s => s.WeaponViewModel          ()) as TViewModel;
            if (type.Equals(typeof(ReadHeroesByNameViewModel))) return Create(s => s.ReadHeroesByNameViewModel()) as TViewModel;

            throw new ArgumentException("Selected generic type doesn't exist.");
        }
    }
}
