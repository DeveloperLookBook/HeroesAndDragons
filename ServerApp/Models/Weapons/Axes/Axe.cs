using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons.Axes
{
    public class Axe : Weapon, IAxe
    {
        public Axe(short strength, DateTime created) : base(strength, created)
        {
        }
    }
}
