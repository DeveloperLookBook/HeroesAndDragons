using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons.Shields
{
    public class Shield : Weapon, IShield
    {
        public Shield() : base("Shield", 4)
        {
        }
    }
}
