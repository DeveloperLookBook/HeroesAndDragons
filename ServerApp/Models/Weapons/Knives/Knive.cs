using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons.Knives
{
    public class Knive : Weapon, IKnive
    {
        public Knive() : base("Knife", 8)
        {
        }
    }
}
