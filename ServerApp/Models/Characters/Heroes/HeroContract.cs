using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Contracts;
using ServerApp.Extencions;
using ServerApp.Models.Weapons;

namespace ServerApp.Models.Characters.Heroes
{
    [NotMapped]
    public class HeroContract : Contract<HeroContract, HeroContract.Key>
    {
        public enum Key
        {
            NameHasPuncuation,
            NameHasMarks,
            NameHasSymbols,
            NameHasControls,
            WeaponIsNull,
        }

        static HeroContract()
        {
            Messages.Add(Key.NameHasPuncuation, "Hero Name mustn't contain Punctuation characters."                                                 );
            Messages.Add(Key.NameHasMarks     , "Hero Name mustn't contain Nonspacing, Spacing Combining and Enclosing diacritic marks."            );
            Messages.Add(Key.NameHasSymbols   , "Hero Name mustn't contain: Math, Currency and Modifier symbols."                                   );
            Messages.Add(Key.NameHasControls  , "Hero Name mustn't contain: Control, Format, Surrogate, Private Use and Not Assigned control characters.");
            Messages.Add(Key.WeaponIsNull     , "Hero Weapon mustn't be Null."                                                                      );
        }

        public void Name  (string paramName, string paramValue, out string result)
        {
            if      (paramName.HasPunctuation()) { throw new ArgumentException(Messages.Get(Key.NameHasPuncuation), paramName); }
            else if (paramName.HasMarks     ()) { throw new ArgumentException(Messages.Get(Key.NameHasMarks     ), paramName); }
            else if (paramName.HasSymbols   ()) { throw new ArgumentException(Messages.Get(Key.NameHasSymbols   ), paramName); }
            else if (paramName.HasControls  ()) { throw new ArgumentException(Messages.Get(Key.NameHasControls  ), paramName); }

            result = paramValue;
        }

        public void Weapon(string paramName, Weapon paramValue, out Weapon result)
        {
            if (paramValue is null) { throw new ArgumentNullException(nameof(Weapon), Messages.Get(Key.WeaponIsNull)); }

            result = paramValue;
        }
    }
}
