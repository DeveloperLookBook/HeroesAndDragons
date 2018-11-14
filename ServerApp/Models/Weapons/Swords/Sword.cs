using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons.Swords
{
    public class Sword : Weapon, ISword
    {
        public Sword() : base("Sword", 20)
        {
        }
    }
}
