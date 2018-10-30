using ServerApp.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Characters
{    
    public interface ICharacter : IModel<int>
    {
        string Name { get; set; }
    }
}
