using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons
{
    public enum WeaponType
    {
        Axe      = 1,
        Crossbow = 2,
        Knive    = 3,
        Rapier   = 4,
        Sword    = 5,
        Shield   = 6
    }
}
