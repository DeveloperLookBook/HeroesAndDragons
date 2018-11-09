using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.ViewModels.Characters.Heroes
{
    public class HeroHitViewModel : ViewModel
    {
        public Guid                Id       { get; set; }                                           
        public CharacterViewModel  Target   { get; set; }
        public WeaponViewModel Weapon   { get; set; }        
        public short               Strength { get; set; }
        public DateTime            Created  { get; set; }
    }
}
