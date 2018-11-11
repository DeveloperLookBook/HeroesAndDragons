using FluentValidation;
using ServerApp.Models.Characters;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Hits;
using ServerApp.Models.Weapons;
using ServerApp.ViewModels.Characters;
using ServerApp.ViewModels.Characters.Dragons;
using ServerApp.ViewModels.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.ViewModels
{
    public delegate TViewModel ViewModelFactorySelectorFunc<TViewModel>(IViewModelCreator creator)
        where TViewModel : class, IViewModel;


    public static class ViewModelFactory
    {
        private class ViewModelCreator : IViewModelCreator
        {
            public DragonViewModel           DragonViewModel          () => new DragonViewModel          ();
            public CreateHeroViewModel       CreateHeroViewModel      () => new CreateHeroViewModel      ();
            public SigninHeroViewModel       SigninHeroViewModel      () => new SigninHeroViewModel      ();
            public HeroViewModel             HeroViewModel            () => new HeroViewModel            ();
            public WeaponViewModel           WeaponViewModel          () => new WeaponViewModel          ();
            public ReadHeroesByNameViewModel ReadHeroesByNameViewModel() => new ReadHeroesByNameViewModel();

            public DragonViewModel           DragonViewModel          (IDragon    dragon   )
            {
                return new DragonViewModel()
                {
                    Id      = dragon.Id,
                    Name    = dragon.Name,
                    Health  = dragon.Health,
                    Created = new DateTime(dragon.Created.Ticks)
                };
            }
            public WeaponViewModel           WeaponViewModel          (IWeapon    weapon   )
            {
                return new WeaponViewModel()
                {
                    Id       = weapon.Id,
                    Name     = weapon.Name,
                    Strength = weapon.Strength
                };
            }
            public HeroViewModel             HeroViewModel            (IHero      hero     )
            {
                return new HeroViewModel()
                {
                    Id      = hero.Id,
                    Name    = hero.Name,
                    Weapon  = this.WeaponViewModel(hero.Weapon),
                    Created = new DateTime(hero.Created.Ticks)
                };
            }
            public CharacterViewModel        CharacterViewModel       (ICharacter character)
            {
                return new CharacterViewModel()
                {
                    Id   = character.Id,
                    Name = character.Name,
                    Type = character.GetType().Name
                };
            }
            public HeroHitViewModel          HeroHitViewModel         (IHit       hit      )
            {
                return new HeroHitViewModel()
                {
                    Id       = hit.Id,
                    Target   = this.CharacterViewModel(hit.Target),
                    Weapon   = this.WeaponViewModel   (hit.Weapon),
                    Strength = hit.Strength,
                    Created  = new DateTime(hit.Created.Ticks),
                };
            }
        }


        static private ViewModelCreator InstanceCreator => new ViewModelCreator();


        static public TViewModel Create<TViewModel>(ViewModelFactorySelectorFunc<TViewModel> selector)
            where TViewModel : class, IViewModel
        {
            return selector(InstanceCreator);
        }        
    }
}
