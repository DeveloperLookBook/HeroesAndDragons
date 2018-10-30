using ServerApp.Contracts;
using ServerApp.Models.Characters;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Weapons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Hits
{
    [NotMapped]
    public class HitContract : Contract<HitContract, HitContract.Key>
    {        
        public enum Key
        {
            HeroIsNull,
            DragonIsNull,
            WeaponIsNull,
            StrengthLessThen1,
            StrengthMoreThen100
        }

        static HitContract()
        {
            Messages.Add(Key.DragonIsNull       , "Hit Target (dragon) mustn't be Null."            );
            Messages.Add(Key.WeaponIsNull       , "Hit Weapon mustn't be Null."                     );
            Messages.Add(Key.HeroIsNull         , "Hit Source (hero) mustn't be Null."              );
            Messages.Add(Key.StrengthLessThen1  , "Hit Strength value must be more or equal to 1."  );
            Messages.Add(Key.StrengthMoreThen100, "Hit Strength value must be less or equal to 100.");
        }
        
        public void Source   (string paramName, IHero   paramValue, out Hero   result)
        {
            if (paramValue is null) { throw new ArgumentNullException(paramName, Messages.Get(Key.HeroIsNull)); }

            result = paramValue as Character;
        }                             
        public void Target   (string paramName, IDragon paramValue, out Dragon result)
        {
            if (paramValue is null) { throw new ArgumentNullException(paramName, Messages.Get(Key.DragonIsNull)); }

            result = paramValue as Character;
        }                             
        public void Weapon   (string paramName, IWeapon paramValue, out Weapon result)
        {
            if (paramValue is null) { throw new ArgumentNullException(paramName, Messages.Get(Key.WeaponIsNull)); }

            result = paramValue as Weapon;
        }
        public void Strength (string paramName, short   paramValue, out short  result)
        {
            if (paramValue < 1  ) { throw new ArgumentException(Messages.Get(Key.StrengthLessThen1  ), paramName); }
            if (paramValue > 100) { throw new ArgumentException(Messages.Get(Key.StrengthMoreThen100), paramName); }

            result = paramValue;
        }
    }
}
