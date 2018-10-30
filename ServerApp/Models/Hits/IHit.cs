using ServerApp.Models.Characters;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Hits
{
    public interface IHit : IModel<Guid>
    {
        Hero   Hero     { get; }
        Dragon Dragon   { get; }
        Weapon Weapon   { get; }
        short  Strength { get; }
    }
}
