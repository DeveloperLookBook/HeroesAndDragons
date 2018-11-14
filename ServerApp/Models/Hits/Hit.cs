using ServerApp.Models.Characters;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Weapons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Hits
{
    public class Hit : Model<Guid>, IHit
    {
        public Character Source   { get; set; }
        public Character Target   { get; set; }
        public Weapon    Weapon   { get; set; }
        public short     Strength { get; set; }        
    }
}
