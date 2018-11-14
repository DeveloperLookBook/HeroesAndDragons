using ServerApp.Models.Hits;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Characters.Dragons
{
    public class Dragon : Character, IDragon
    {
        #region FIELDS

        private short  _health;

        #endregion


        #region PROPERTIES

        public short  Health
        {
            get => this._health;
            set
            {
                var min = DragonHealth.MinValue;
                var max = DragonHealth.MaxValue;

                this._health = (short)((value < min) ? min : (value > max) ? max : value);
            }
        }

        #endregion


        #region CONSTRUCTORS

        public Dragon(string name, short health) : base(name) => this.Health = health;

        #endregion        
    }
}
