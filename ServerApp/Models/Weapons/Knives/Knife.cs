using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons.Knives
{
    public class Knife : Weapon, IKnife
    {
        public Knife(short strength, DateTime created) : base(strength, created)
        {
        }
    }
}
