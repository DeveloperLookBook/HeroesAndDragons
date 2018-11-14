using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons.Rapiers
{
    public class Rapier : Weapon, IRapier
    {
        public Rapier() : base("Rapier", 15)
        {
        }
    }
}
