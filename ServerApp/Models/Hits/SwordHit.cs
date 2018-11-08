﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Models.Characters;
using ServerApp.Models.Weapons;

namespace ServerApp.Models.Hits
{
    public class SwordHit : Hit
    {
        public SwordHit(Character source, Character target, Weapon weapon, short strength) : base(source, target, weapon, strength)
        {
        }
    }
}
