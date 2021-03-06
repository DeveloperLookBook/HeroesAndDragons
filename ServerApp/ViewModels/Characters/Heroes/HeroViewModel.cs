﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.ViewModels.Characters.Heroes
{
    public class HeroViewModel : ViewModel
    {
        public int             Id      { get; set; }
        public string          Name    { get; set; }
        public WeaponViewModel Weapon  { get; set; }
        public DateTime        Created { get; set; }       
    }
}
