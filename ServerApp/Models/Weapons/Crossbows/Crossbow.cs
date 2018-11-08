using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons.Crossbows
{
    public class Crossbow : Weapon, ICrossbow
    {
        public Crossbow() : base((int)WeaponType.Crossbow, "Crossbow", 15)
        {
        }
    }
}
