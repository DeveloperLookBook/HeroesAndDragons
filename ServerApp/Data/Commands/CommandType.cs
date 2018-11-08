using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Commands
{
    public enum CommandType
    {
        CreateHero,
        ReadHeroes,

        CreateDragon,
        ReadDragons,

        CreateHit,
        ReadHits,
    }
}
