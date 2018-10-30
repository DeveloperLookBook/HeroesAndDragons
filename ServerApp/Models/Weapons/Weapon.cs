using ServerApp.Data;
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

        short  _strength;
        string _name;

        #endregion


        #region PROPERTIES

        public string Name     => this._name;
        public short  Strength => this._strength;

        #endregion
    }
}
