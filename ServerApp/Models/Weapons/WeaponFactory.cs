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

namespace ServerApp.Models.Weapons
{
    public interface IWeaponCreator
    {
        Axe      Axe     ();
        Crossbow Crossbow();
        Knive    Knive   ();
        Rapier   Rapier  ();
        Shield   Shield  ();
        Sword    Sword   ();
        Weapon   Random  ();
    }


    public delegate TWeapon WeaponFactorySelectorFunc<TWeapon>(IWeaponCreator creator) 
        where TWeapon : class, IWeapon;


    [NotMapped]
    public static class WeaponFactory
    {
        private class Creator : IWeaponCreator
        {
            static private Random     RandomNumberGenerator => new Random();


            static private TCastTo[]  GetEnumConstantValues<TCastTo>(Type type) 
                where TCastTo : IComparable<TCastTo>
            {
                return Enum.GetValues(type).Cast<TCastTo>().ToArray();
            }

            static private T          GetRandomValue       <T>      (T[] array) 
                where T : IComparable<T>
            {
                return array[RandomNumberGenerator.Next(0, array.Count() - 1)];
            }


            public Weapon   Random  ()
            {
                var constants  = GetEnumConstantValues<int>(typeof(WeaponType));
                var index      = GetRandomValue            (constants         );

                switch ((WeaponType)index)
                {
                    case WeaponType.Axe     : return this.Axe     ();
                    case WeaponType.Crossbow: return this.Crossbow();
                    case WeaponType.Knive   : return this.Knive   ();
                    case WeaponType.Rapier  : return this.Rapier  ();
                    case WeaponType.Sword   : return this.Sword   ();
                    case WeaponType.Shield  : return this.Shield  ();

                    default:
                        throw new ArgumentException(
                            $@"Automatically generated constant value " +
                            $@"of the enum - { nameof(WeaponType) } , " +
                            "doesn't exist.");
                }
            }                                
            public Axe      Axe     () => new Axe     ();
            public Crossbow Crossbow() => new Crossbow();
            public Knive    Knive   () => new Knive   ();
            public Rapier   Rapier  () => new Rapier  ();
            public Shield   Shield  () => new Shield  ();
            public Sword    Sword   () => new Sword   ();
        }


        static private Creator InstanceCreator => new Creator();


        static public TWeapon Create<TWeapon>(WeaponFactorySelectorFunc<TWeapon> selector)
            where TWeapon : class, IWeapon
        {
            if (selector is null) throw new ArgumentNullException(nameof(selector));

            return selector(InstanceCreator);
        }
    }    
}
