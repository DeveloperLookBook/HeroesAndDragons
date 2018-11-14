using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Extencions;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Hits;
using ServerApp.Models.Weapons;

namespace ServerApp.Models.Characters.Heroes
{
    public class Hero : Character, IHero
    {

        #region PROPERTIES

        public Weapon Weapon   { get; set; }

        #endregion


        #region CONSTRUCTORS

        public Hero(string name) : base(name) { }

        #endregion


        #region METHODS

        public IHit Hit(IDragon dragon)
        {
            if (dragon is null) throw new ArgumentNullException(nameof(dragon));

            var hit = HitFactory.Create(s => s.Hit(this, dragon, this.Weapon));

            if (hit    is null) throw new ArgumentNullException(nameof(hit   ));

            dragon.Health -= hit.Strength;

            return hit;
        }

        #endregion
    }
}
