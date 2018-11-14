using NUnit.Framework;
using ServerApp.Models.Characters;
using ServerApp.Models.Characters.Dragons;
using ServerApp.Models.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.Tests.Models.Characters
{
    class CharacterFactoryTests
    {
        [Test]
        public void CreateHero()
        {
            // Arrange
            var heroName = "Name";


            // Act
            Hero hero = CharacterFactory.Create(s => s.Hero(heroName));


            // Assert
            Assert.That(hero.Name         , Is.EqualTo(heroName));
            Assert.That(hero.Weapon       , Is.Not.Null);
            Assert.That(hero.Weapon.Id    , Is.GreaterThanOrEqualTo(0));
            Assert.That(hero.Weapon.Name  , Is.Not.Null);
            Assert.That(hero.Weapon.Name  , Has.Length.GreaterThanOrEqualTo(4 ));
            Assert.That(hero.Weapon.Name  , Has.Length.LessThanOrEqualTo   (20));
            Assert.That(hero.Created.Day  , Is.EqualTo(DateTime.Now.Day));
            Assert.That(hero.Created.Ticks, Is.LessThanOrEqualTo(DateTime.Now.Ticks));
        }

        [Test]
        public void CreateDragom()
        {            
            // Act
            Dragon dragon = CharacterFactory.Create(s => s.Dragon());


            // Assert
            Assert.That(dragon.Name         , Is.Not.Null);
            Assert.That(dragon.Name.Length  , Is.GreaterThanOrEqualTo(4));
            Assert.That(dragon.Name.Length  , Is.LessThanOrEqualTo(20));
            Assert.That(dragon.Health       , Is.GreaterThanOrEqualTo(80));
            Assert.That(dragon.Health       , Is.LessThanOrEqualTo(100));
            Assert.That(dragon.Created.Day  , Is.EqualTo(DateTime.Now.Day));
            Assert.That(dragon.Created.Ticks, Is.LessThanOrEqualTo(DateTime.Now.Ticks));
        }
    }
}
