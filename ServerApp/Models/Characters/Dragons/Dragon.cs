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
        private short  _health;

        #endregion


        #region PROPERTIES

        public override string Name   { get => this._name  ; set => Contract.Name       (nameof(value), value, out this._name  ); }
        public          short  Health { get => this._health; set => Contract.LivesNumber(nameof(value), value, out this._health); }

        [NotMapped]
        private static  DragonContract Contract => new DragonContract();

        #endregion


        #region CONSTRUCTORS

        public Dragon(string name, short health) : base(name) => this.Health = health;

        #endregion
    }
}
