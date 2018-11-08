using ServerApp.Models.Characters;
using ServerApp.Models.Weapons;
using System;

namespace ServerApp.Models.Hits
{
    public interface IHit : IModel<Guid>
    {
        Character Source   { get; }
        short     Strength { get; }
        Character Target   { get; }
        Weapon    Weapon   { get; }
    }
}