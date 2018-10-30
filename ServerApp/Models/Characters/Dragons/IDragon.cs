using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Characters.Dragons
{
    public interface IDragon: ICharacter
    {
        short Health { get; set; }
    }
}
