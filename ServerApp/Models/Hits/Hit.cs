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
        #region FIELDS

        private Hero   _hero    ;
        private Dragon _dragon  ;
        private Weapon _weapon  ;
        private short  _strength;

        #endregion


        #region PROPERTIES

        public Hero   Hero     => this._hero    ;
        public Dragon Dragon   => this._dragon  ;
        public Weapon Weapon   => this._weapon  ;
        public short  Strength => this._strength;

        [NotMapped]
        public static HitContract Contract => new HitContract();

        #endregion


        #region CONSTRUCTORS

        public Hit(IHero hero, IDragon dragon, IWeapon weapon, short strength, DateTime created) : base(created)
        {
            Contract.Source  (nameof(hero    ), hero    , out this._hero    );
            Contract.Target  (nameof(dragon  ), dragon  , out this._dragon  );
            Contract.Weapon  (nameof(weapon  ), weapon  , out this._weapon  );
            Contract.Strength(nameof(strength), strength, out this._strength);
        }

        #endregion
    }
}
