using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Extencions;
using ServerApp.Models.Weapons;

namespace ServerApp.Models.Characters
{
    public abstract class Character : Model<Guid>, ICharacter<Guid>
    {
        #region PROPERTIES

        public abstract string Name { get; set; }

        [NotMapped]
        private CharacterContract Contract => new CharacterContract();

        #endregion


        #region CONSTRUCTORS        

        protected Character(string name, DateTime created) : base(created)
        {
            Contract.Name(nameof(name), name, out var result);

            this.Name = result;
        }

        #endregion
    }
}
