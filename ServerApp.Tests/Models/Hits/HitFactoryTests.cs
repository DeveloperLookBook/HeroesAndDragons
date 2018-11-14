using NUnit.Framework;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Hits;
using ServerApp.Models.Weapons.Axes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.Tests.Models.Hits
{
    class HitFactoryTests
    {
        [Test]
        public void CreateHit()
        {
            // Arrange
            var weapon = new Axe   ();
            var hero   = new Hero  ("Heroname") { Weapon = weapon };
            var dragon = new Dragon("Dragonname", 100);


            // Act
            var hit = HitFactory.Create(s => s.Hit(hero, dragon, weapon));

            // Assert
            Assert.That(hit               , Is.Not.Null);

            Assert.That(hit.Source        , Is.Not.Null             );
            Assert.That(hit.Source.Id     , Is.EqualTo(hero.Id     ));
            Assert.That(hit.Source.Name   , Is.EqualTo(hero.Name   ));
            Assert.That(hit.Source.Created, Is.EqualTo(hero.Created));

            Assert.That(hit.Target        , Is.Not.Null               );
            Assert.That(hit.Target.Id     , Is.EqualTo(dragon.Id     ));
            Assert.That(hit.Target.Name   , Is.EqualTo(dragon.Name   ));
            Assert.That(hit.Target.Created, Is.EqualTo(dragon.Created));

            Assert.That(hit.Weapon         , Is.Not.Null                );
            Assert.That(hit.Weapon.Id      , Is.EqualTo(weapon.Id      ));
            Assert.That(hit.Weapon.Name    , Is.EqualTo(weapon.Name    ));
            Assert.That(hit.Weapon.Strength, Is.EqualTo(weapon.Strength));
            Assert.That(hit.Weapon.Created , Is.EqualTo(weapon.Created ));

            Assert.That(hit.Created.Day    , Is.EqualTo          (DateTime.Now.Day  ));
            Assert.That(hit.Created.Ticks  , Is.LessThanOrEqualTo(DateTime.Now.Ticks));
        }
    }
}
