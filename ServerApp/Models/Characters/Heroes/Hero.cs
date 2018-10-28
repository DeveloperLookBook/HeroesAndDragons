using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Extencions;
using ServerApp.Models.Weapons;

namespace ServerApp.Models.Characters.Heroes
{
    public class Hero : Character, IHero
    {
        #region FIELDS

        private string _name;
        private Weapon _weapon;

        #endregion


        #region PROPERTIES

        public override string Name
        {
            get => this._name;
            set => Contract.Name  (nameof(Name  ), value, out this._name);            
        }

        public          Weapon Weapon
        {
            get => this._weapon;
            set => Contract.Weapon(nameof(Weapon), value, out this._weapon);
        }
        
        public string Token
        {
            get;
            set;
        }

        [NotMapped]
        private static HeroContract Contract => new HeroContract();

        #endregion


        #region CONSTRUCTORS

        public Hero(string name, Weapon weapon, DateTime created) : base(name, created)
        {
            this.Weapon = weapon;          
        }

        #endregion
    }
}
