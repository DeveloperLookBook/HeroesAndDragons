using ServerApp.Models.Weapons;
using System;

namespace ServerApp.Models.Characters.Heroes
{
    public interface IHero : ICharacter<Guid>
    {
        Weapon Weapon { get; set; }
    }
}