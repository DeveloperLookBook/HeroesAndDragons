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

        private string _name;
        private short  _livesNumber;

        #endregion


        #region PROPERTIES

        public override string Name        { get => this._name       ; set => Contract.Name       (nameof(Name       ), value, out this._name       ); }
        public          short  LivesNumber { get => this._livesNumber; set => Contract.LivesNumber(nameof(LivesNumber), value, out this._livesNumber); }

        [NotMapped]
        private static  DragonContract Contract => new DragonContract();

        #endregion


        #region CONSTRUCTORA

        public Dragon(string name, short livesNumber, DateTime created) : base(name, created)
        {
            this.LivesNumber = livesNumber;
        }

        #endregion
    }
}
