using ServerApp.Models.Weapons;
using System;

namespace ServerApp.Models.Characters.Heroes
{
    public interface IHero : ICharacter
    {
        Weapon Weapon { get; set; }
    }
}