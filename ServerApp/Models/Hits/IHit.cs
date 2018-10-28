using ServerApp.Models.Characters;
using ServerApp.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Hits
{
    public interface IHit : IModel<Guid>
    {
        Character Source   { get; }
        Character Target   { get; }
        Weapon    Weapon   { get; }
        short     Strength { get; }
    }
}
