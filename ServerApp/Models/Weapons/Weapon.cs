using ServerApp.Data;
using ServerApp.Extencions;
using ServerApp.Models.Characters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Weapons
{
    public abstract class Weapon : Model<int>, IWeapon
    {
        #region PROPERTIES

        public string    Name     { get; private set; }
        public short     Strength { get; private set; }
        
        #endregion


        #region CONSTRUCTORS

        protected Weapon(string name, short strength)
        {
            this.Name     = name;
            this.Strength = strength;
        }

        #endregion
    }
}
