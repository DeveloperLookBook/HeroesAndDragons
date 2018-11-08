using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Hits
{
    [NotMapped]
    public class StrengthMultiplier
    {
        static public  short  MinValue       => 1;
        static public  short  MaxValue       => 3;
               private Random ValueGenerator => new Random();
               public  short  Value          => (short)this.ValueGenerator.Next(MinValue, MaxValue);
    }
}
