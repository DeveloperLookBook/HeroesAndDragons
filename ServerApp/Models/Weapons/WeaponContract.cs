using ServerApp.Contracts;
using ServerApp.Extencions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons
{
    [NotMapped]
    public class WeaponContract : Contract<WeaponContract, WeaponContract.Key>
    {
        public enum Key
        {
            NameIsNull,
            NameIsEmtpy,
            NameIsNotTrimed,
            StrengthLessThen1,
            StrengthMoreThen100,
        }

        static WeaponContract()
        {
            Messages.Add(Key.NameIsNull         , "Weapon Name mustn't be Null."                       );
            Messages.Add(Key.NameIsEmtpy        , "Weapon Name mustn't be Empty."                      );
            Messages.Add(Key.NameIsNotTrimed    , "Weapon Name must be Trimmed."                       );
            Messages.Add(Key.StrengthLessThen1  , "Weapon Strength value must be more or equal to 1."  );
            Messages.Add(Key.StrengthMoreThen100, "Weapon Strength value must be less or equal to 100.");
        }                

        public virtual void Name    (string paramName, string paramValue, out string result)
        {
            if (paramValue.IsNull ()) { throw new ArgumentNullException(paramName, Messages.Get(Key.NameIsNull     )); }
            if (paramValue.IsNull ()) { throw new ArgumentNullException(paramName, Messages.Get(Key.NameIsNull     )); }
            if (paramValue.IsEmpty()) { throw new ArgumentException    (Messages.Get(Key.NameIsEmtpy    ), paramName); }
            if (paramValue.Trimed ()) { throw new ArgumentException    (Messages.Get(Key.NameIsNotTrimed), paramName); }

            result = paramValue;
        }

        public         void Strength(string paramName, short  paramValue, out short result)
        {
            if (paramValue < 1  ) { throw new ArgumentException(Messages.Get(Key.StrengthLessThen1  ), paramName); }
            if (paramValue > 100) { throw new ArgumentException(Messages.Get(Key.StrengthMoreThen100), paramName); }

            result = paramValue;
        }        
    }
}
