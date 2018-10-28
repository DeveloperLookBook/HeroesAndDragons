using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons
{
    [NotMapped]
    public enum WeaponType
    {
        Axe,
        Crossbow,
        Knife,
        Rapier,
        Sword,
        Shield
    }
}
