using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.Extencions;
using ServerApp.Models.Weapons;

namespace ServerApp.Models.Characters
{
    public abstract class Character : Model<int>, ICharacter
    {
        public string Name { get; set; }


        protected Character(string name) => this.Name = name;
    }
}
