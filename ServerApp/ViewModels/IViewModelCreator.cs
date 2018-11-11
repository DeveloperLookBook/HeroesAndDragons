﻿using ServerApp.Models.Characters;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Hits;
using ServerApp.Models.Weapons;
using ServerApp.ViewModels.Characters;
using ServerApp.ViewModels.Characters.Dragons;
using ServerApp.ViewModels.Characters.Heroes;

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


        DragonViewModel           DragonViewModel   (IDragon    dragon   );
        WeaponViewModel           WeaponViewModel   (IWeapon    weapon   );
        HeroViewModel             HeroViewModel     (IHero      hero     );
        CharacterViewModel        CharacterViewModel(ICharacter character);
        HeroHitViewModel          HeroHitViewModel  (IHit       hit      );
    }
}
