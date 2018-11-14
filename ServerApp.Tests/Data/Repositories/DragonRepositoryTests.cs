using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ServerApp.Data;
using ServerApp.Data.Repositories;
using ServerApp.Models.Characters.Dragons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Tests.Data.Repositories
{
    class DragonRepositoryTests
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
            using (var context = new GameDbContext(DbContextOptions))
            {
                // Arrange
                var repository = new DragonsRepository(context);
                var dragons    = repository.Request();
                var dragon     = new Dragon("Name1", 100);

                // Assert
                Assert.That(repository                         , Is.Not.Null      );

                // Act
                repository.Add(dragon);

                // Assert
                Assert.That(await dragons.CountAsync   ()      , Is.Not.EqualTo(0));
                Assert.That(await dragons.ContainsAsync(dragon), Is.True          );
            }
        }

        [Test]
        public void Update()
        {
            using (var context = new GameDbContext(DbContextOptions))
            {
                // Arrange
                var repository  = new DragonsRepository(context);
                var dragons     = repository.Request();
                var dragon1Name = "Name1";
                var dragon1     = new Dragon(dragon1Name, 100);

                repository.Add(dragon1);                

                // Act
                var changedDragonName = "Changed";

                dragon1.Name = changedDragonName;
                repository.Update(dragon1);

                var dragon2 = dragons.First(d => d.Id == dragon1.Id);

                // Assert:

                Assert.That(dragon2     , Is.Not.Null                  );
                Assert.That(dragon2.Name, Is.EqualTo(changedDragonName));
            }
        }
    }
}
