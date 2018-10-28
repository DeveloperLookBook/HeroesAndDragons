using ServerApp.Contracts;
using ServerApp.Extencions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Characters
{
    [NotMapped]
    public class CharacterContract : Contract<CharacterContract, CharacterContract.Key>
    {
        public enum Key
        {
            NameIsNull,
            NameIsEmpty,
            NameIsNotTrimed,
            NameLengthIsGreaterThen20,
            NameLengthIsLessThen4,
            NameHasDisallowedSeparators,
            NameHasDisallowedLetters,
        }

        static CharacterContract()
        {
            Messages.Add(Key.NameIsNull                 , "Name mustn't be Null."                                           );
            Messages.Add(Key.NameIsEmpty                , "Name mustn't be Empty."                                          );
            Messages.Add(Key.NameIsNotTrimed            , "Name must be Trimmed."                                           );
            Messages.Add(Key.NameLengthIsGreaterThen20  , "Name Length must be less or equal - 20."                         );
            Messages.Add(Key.NameLengthIsLessThen4      , "Name Length must be more or equal - 4."                          );
            Messages.Add(Key.NameHasDisallowedSeparators, "Name mustn't contain any separator characters except whitespaces");
            Messages.Add(Key.NameHasDisallowedLetters   , "Name can contain Latin letters only: a-z, A-Z."                  );
        }

        private bool HasDisallowedSeparators(string value) => value.IsMatch(@"\A[\P{Z} ]*\z"     );
        private bool HasDisallowedLetters   (string value) => value.IsMatch(@"\A[\P{L}a-zA-Z]*\z");

        public virtual void Name(string paramName, string paramValue, out string result)
        {
            if (paramValue.IsNull      (          )) { throw new ArgumentNullException(Messages.Get(Key.NameIsNull                 ), paramName);}
            if (paramValue.IsEmpty     (          )) { throw new ArgumentException    (Messages.Get(Key.NameIsEmpty                ), paramName);}
            if (paramValue.Trimed      (          )) { throw new ArgumentException    (Messages.Get(Key.NameIsNotTrimed            ), paramName);}
            if (paramValue.HasMaxLemgth(20        )) { throw new ArgumentException    (Messages.Get(Key.NameLengthIsGreaterThen20  ), paramName);}
            if (paramValue.HasMinLength(4         )) { throw new ArgumentException    (Messages.Get(Key.NameLengthIsLessThen4      ), paramName);}
            if (HasDisallowedSeparators(paramValue)) { throw new ArgumentException    (Messages.Get(Key.NameHasDisallowedSeparators), paramName);}
            if (HasDisallowedLetters   (paramValue)) { throw new ArgumentException    (Messages.Get(Key.NameHasDisallowedLetters   ), paramName);}

            result = paramValue;
        }
    }
}
