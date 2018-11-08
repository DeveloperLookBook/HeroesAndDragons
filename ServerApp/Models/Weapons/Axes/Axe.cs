using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons.Axes
{
    public class Axe : Weapon, IAxe
    {
        public Axe() : base((int)WeaponType.Axe, "Axe", 18)
        {
        }
    }
}
