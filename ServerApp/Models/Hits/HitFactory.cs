using ServerApp.Models.Characters;
using ServerApp.Models.Weapons;
using ServerApp.Models.Weapons.Axes;
using ServerApp.Models.Weapons.Crossbows;
using ServerApp.Models.Weapons.Knifes;
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
    public interface IHitCreator
    {
        AxeHit      AxeHit     (Character source, Character target, Weapon weapon);
        CrossbowHit CrossbowHit(Character source, Character target, Weapon weapon);
        KnifeHit    KnifeHit   (Character source, Character target, Weapon weapon);
        RapierHit   RapierHit  (Character source, Character target, Weapon weapon);
        ShieldHit   ShieldHit  (Character source, Character target, Weapon weapon);
        SwordHit    SwordHit   (Character source, Character target, Weapon weapon);
    }


    public delegate THit HitFactorySelectorFunc<THit>(IHitCreator creator) where THit : class, IHit;


    [NotMapped]
    public static class HitFactory
    {
        private class Creator : IHitCreator
        {
            static private StrengthMultiplier StrengthMultiplier => new StrengthMultiplier();


            public AxeHit      AxeHit     (Character source, Character target, Weapon weapon)
            {
                return new AxeHit(source, target, weapon, StrengthMultiplier.Value);
            }
            public CrossbowHit CrossbowHit(Character source, Character target, Weapon weapon)
            {
                return new CrossbowHit(source, target, weapon, StrengthMultiplier.Value);
            }
            public KnifeHit    KnifeHit   (Character source, Character target, Weapon weapon)
            {
                return new KnifeHit(source, target, weapon, StrengthMultiplier.Value);
            }
            public RapierHit   RapierHit  (Character source, Character target, Weapon weapon)
            {
                return new RapierHit(source, target, weapon, StrengthMultiplier.Value);
            }
            public ShieldHit   ShieldHit  (Character source, Character target, Weapon weapon)
            {
                return new ShieldHit(source, target, weapon, StrengthMultiplier.Value);
            }
            public SwordHit    SwordHit   (Character source, Character target, Weapon weapon)
            {
                return new SwordHit(source, target, weapon, StrengthMultiplier.Value);
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
