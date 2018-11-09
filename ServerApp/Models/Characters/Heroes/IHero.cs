using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Hits;
using ServerApp.Models.Weapons;
using System;

namespace ServerApp.Models.Characters.Heroes
{
    public interface IHero : ICharacter
    {
        Weapon Weapon { get; set; }

        IHit Hit(IDragon dragon);
    }
}