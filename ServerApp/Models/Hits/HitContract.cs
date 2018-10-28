﻿using ServerApp.Contracts;
using ServerApp.Models.Characters;
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
            SourceIsNull,
            TargetIsNull,
            WeaponIsNull,
            StrengthLessThen1,
            StrengthMoreThen100
        }

        static HitContract()
        {
            Messages.Add(Key.TargetIsNull       , "Hit Target mustn't be Null."                     );
            Messages.Add(Key.WeaponIsNull       , "Hit Weapon mustn't be Null."                     );
            Messages.Add(Key.SourceIsNull       , "Hit Source mustn't be Null."                     );
            Messages.Add(Key.StrengthLessThen1  , "Hit Strength value must be more or equal to 1."  );
            Messages.Add(Key.StrengthMoreThen100, "Hit Strength value must be less or equal to 100.");
        }
        
        public void Source   (string paramName, ICharacter paramValue, out Character result)
        {
            if (paramValue is null) { throw new ArgumentNullException(paramName, Messages.Get(Key.SourceIsNull)); }

            result = paramValue as Character;
        }                             
        public void Target   (string paramName, ICharacter paramValue, out Character result)
        {
            if (paramValue is null) { throw new ArgumentNullException(paramName, Messages.Get(Key.TargetIsNull)); }

            result = paramValue as Character;
        }                             
        public void Weapon   (string paramName, IWeapon    paramValue, out Weapon    result)
        {
            if (paramValue is null) { throw new ArgumentNullException(paramName, Messages.Get(Key.WeaponIsNull)); }

            result = paramValue as Weapon;
        }
        public void Strength (string paramName, short      paramValue, out short     result)
        {
            if (paramValue < 1  ) { throw new ArgumentException(Messages.Get(Key.StrengthLessThen1  ), paramName); }
            if (paramValue > 100) { throw new ArgumentException(Messages.Get(Key.StrengthMoreThen100), paramName); }

            result = paramValue;
        }
    }
}