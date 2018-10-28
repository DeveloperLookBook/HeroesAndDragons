using ServerApp.Extencions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons
{
    public abstract class Weapon : Model<int>, IWeapon
    {
        #region FIELDS

        private readonly short  _strength;

        #endregion


        #region PROPERTIES

        public short  Strength => this._strength;

        [NotMapped]
        private static WeaponContract  Contract => new WeaponContract();

        #endregion


        #region CONSTRUCTORS

        public Weapon(short strength, DateTime created) : base(created)
        {
            Contract.Strength(nameof(strength), strength, out this._strength);
        }

        #endregion
    }
}
