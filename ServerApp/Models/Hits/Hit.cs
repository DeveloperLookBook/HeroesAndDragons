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

        private Character _source  ;
        private Character _target  ;
        private Weapon    _weapon  ;
        private short     _strength;

        #endregion


        #region PROPERTIES

        public Character Source   => this._source  ;
        public Character Target   => this._target  ;
        public Weapon    Weapon   => this._weapon  ;
        public short     Strength => this._strength;

        [NotMapped]
        public static HitContract Contract => new HitContract();

        #endregion


        #region CONSTRUCTORS

        public Hit(Character source, Character target, Weapon weapon, short strength)
        {
            Contract.Source  (nameof(source  ), source  , out source  );
            Contract.Target  (nameof(target  ), target  , out target  );
            Contract.Weapon  (nameof(weapon  ), weapon  , out weapon  );
            Contract.Strength(nameof(strength), strength, out strength);

            this._source   = source;
            this._target   = target;
            this._weapon   = weapon;
            this._strength = strength;
        }

        #endregion
    }
}
