using ServerApp.Extencions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Characters.Dragons
{
    [NotMapped]
    public class DragonNameGenerator
    {
        public string Generate()
        {
            var dragonName         = new DragonName();
            var random             = new Random();
            var expectedNameLength = random.Next(DragonName.MinLength, 6);

            while (dragonName.ActualLength < expectedNameLength)
            {
                // Create first letter:                
                if (dragonName.ActualLength == 0)
                {
                    if (expectedNameLength % 2 == 0)
                    {
                        dragonName.Value = dragonName.Value.AppendRandomLatinVowelLetter();
                    }
                    else
                    {
                        dragonName.Value = dragonName.Value.AppendRandomLatinConsonantLetter();
                    }

                    dragonName.Value = dragonName.Value.ToUpper();
                }                

                // Create letter:                
                if (dragonName.Value.IsLastLetterLatinConsonant())
                {
                    dragonName.Value = dragonName.Value.AppendRandomLatinVowelLetter();
                }
                else
                {
                    dragonName.Value = dragonName.Value.AppendRandomLatinConsonantLetter();
                }                
            }            

            return dragonName.Value;

        }
    }
}
