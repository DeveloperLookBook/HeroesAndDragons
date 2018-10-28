using ServerApp.Contracts;
using ServerApp.Extencions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Characters.Dragons
{
    [NotMapped]
    public class DragonContract : Contract<DragonContract, DragonContract.Key>
    {
        public enum Key
        {
            NameIsNotSentenceCased,
            NameContainsNumbers,
            LivesNumberIsLess0,
            LivesNumberIsGreater100,
        }

        static DragonContract()
        {
            Messages.Add(Key.NameIsNotSentenceCased , "First letter in the Dragon name must be uppercased.");
            Messages.Add(Key.NameContainsNumbers    , "Dragon Name mustn't contain numbers.");
            Messages.Add(Key.LivesNumberIsLess0     , "Dragon Name length mustn't be less then 0.");
            Messages.Add(Key.LivesNumberIsGreater100, "Dragon Name length mustn't be greater then 100.");
        }

        public void Name(string paramName, string paramValue, out string result)
        {
            if (paramValue.SentenceCased()) { throw new ArgumentException(Messages.Get(Key.NameIsNotSentenceCased), paramName); }
            if (paramValue.HasNumbers   ()) { throw new ArgumentException(Messages.Get(Key.NameContainsNumbers   ), paramName); }

            result = paramValue;
        }

        public void LivesNumber(string paramName, short paramValue, out short result)
        {
            if (paramValue < 0  ) { throw new ArgumentException(Messages.Get(Key.LivesNumberIsLess0     )); }
            if (paramValue > 100) { throw new ArgumentException(Messages.Get(Key.LivesNumberIsGreater100)); }

            result = paramValue;
        }
    }
}
