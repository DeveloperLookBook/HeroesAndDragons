using ServerApp.Models.Characters;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Weapons;
using ServerApp.Models.Weapons.Axes;
using ServerApp.Models.Weapons.Crossbows;
using ServerApp.Models.Weapons.Knives;
using ServerApp.Models.Weapons.Rapiers;
using ServerApp.Models.Weapons.Shields;
using ServerApp.Models.Weapons.Swords;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models.Hits
{
    public delegate THit HitFactorySelectorFunc<THit>(IHitCreator creator) where THit : class, IHit;


    [NotMapped]
    public static class HitFactory
    {
        private class Creator : IHitCreator
        {
            static private StrengthMultiplier StrengthMultiplier => new StrengthMultiplier();


            public Hit Hit (ICharacter source, ICharacter target, IWeapon weapon)
            {
                return new Hit
                {
                    Source   = (Character)source,
                    Target   = (Character)target,
                    Weapon   = (Weapon   )weapon,
                    Strength = StrengthMultiplier.Value
                };
            }            
        }


        static private Creator InstanceCreator => new Creator();


        static public THit Create<THit>(HitFactorySelectorFunc<THit> selector) where THit : class, IHit 
        {
            if (selector is null) { throw new ArgumentNullException(nameof(selector)); }

            return selector(InstanceCreator);
        }
    }
}
