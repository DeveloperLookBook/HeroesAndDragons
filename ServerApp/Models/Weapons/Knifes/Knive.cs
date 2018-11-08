using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons.Knifes
{
    public class Knife : Weapon, IKnive
    {
        public Knife() : base((int)WeaponType.Knife, "Knife", 8)
        {
        }
    }
}
