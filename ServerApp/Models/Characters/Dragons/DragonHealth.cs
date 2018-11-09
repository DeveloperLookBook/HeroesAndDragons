using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Characters.Dragons
{
    [NotMapped]
    public class DragonHealth
    {
        static public  short  MinValue      => 0;
        static public  short  MaxValue      => 100;
        static private short  StartMinValue => 80;
        static private short  StartMaxValue => 100;
        static private Random Random        => new Random();
               public  short  Generate()    => (short)Random.Next((int)StartMinValue, (int)StartMaxValue);
    }
}
