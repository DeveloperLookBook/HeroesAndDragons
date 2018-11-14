using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ServerApp.Data;
using ServerApp.Data.Repositories;
using ServerApp.Models.Characters.Heroes;
using ServerApp.Models.Weapons.Axes;
using ServerApp.Models.Weapons.Crossbows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Tests.Data.Repositories
{
    class HeroRepositoryTests
    {
        public DbContextOptions<GameDbContext> DbContextOptions { get; set; }

        [OneTimeSetUp]
        public void HeroRepositoryTestsOneTimeSetUp()
        {
            this.DbContextOptions = new DbContextOptionsBuilder<GameDbContext>()
                .UseInMemoryDatabase(databaseName: "GameDb")
                .Options;
        }

        [Test]
        public async Task Add()
        {
            // Arrange:

            var axe1  = new Axe();
            var hero1 = new Hero("Hero1") { Weapon = axe1 };
            var axe2  = new Axe();
            var hero2 = new Hero("Hero2") { Weapon = axe2 };

            using (var context = new GameDbContext(this.DbContextOptions))
            {
                var repository = new HeroesRepository(context);
                var heroes     = repository.Request();


                // Assert
                Assert.That(repository                       , Is.Not.Null      );
                Assert.That(await heroes.CountAsync()        , Is.EqualTo(0)    );


                // Act:
                repository.Add(hero1);
                repository.Add(hero2);
                  
                
                // Assert
                Assert.That(repository                       , Is.Not.Null      );

                Assert.That(await heroes.CountAsync   ()     , Is.Not.EqualTo(0));
                Assert.That(await heroes.ContainsAsync(hero1), Is.True          );
                Assert.That(await heroes.CountAsync   ()     , Is.EqualTo(2)    );                

                Assert.That(await heroes.ContainsAsync(hero2), Is.True          );

                var hero = heroes.First(h => h.Id == hero1.Id);

                Assert.That(hero                             , Is.Not.Null              );
                Assert.That(hero.Weapon.Name                 , Is.EqualTo(axe1.Name    ));      
                Assert.That(hero.Weapon.Strength             , Is.EqualTo(axe1.Strength));
            }            
        
        }

        [Test]
        public void Update()
        {
            using (var context = new GameDbContext(this.DbContextOptions))
            {
                // Arrange:
                var axe1       = new Axe();
                var hero1Name  = "Hero1";
                var hero1      = new Hero(hero1Name) { Weapon = axe1 };
                var repository = new HeroesRepository(context);
                var heroes     = repository.Request();

                repository.Add(hero1);

                // Act:
                var newHero1Name  = "Changed";
                hero1.Name = newHero1Name;
                repository.Update(hero1);

                var hero = heroes.First(h => h.Id == hero1.Id);

                // Assert:

                Assert.That(hero     , Is.Not.Null             );
                Assert.That(hero.Name, Is.EqualTo(newHero1Name));

            }
        }
    }
}
