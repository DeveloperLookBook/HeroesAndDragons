using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ServerApp.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ServerApp.Data.Repositories;
using ServerApp.Data.Commands;
using ServerApp.Data.Receivers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace ServerApp.Tests.Data.Commands
{
    //class CreateHeroCommandTests
    //{


    //    [Test]
    //    public void InvokCreateHeroCommand()
    //    {
    //        // Arrange
    //        var server = new TestServer(new WebHostBuilder()
    //           .UseStartup<Startup>());

    //        var client = server.CreateClient();




    //        //// Arrange
    //        //var options = new DbContextOptionsBuilder<GameDbContext>()
    //        //                 .UseInMemoryDatabase("HeroesAndDragons")
    //        //                 .Options;

    //        //// Run the test against one instance of the context
    //        //using (var context = new GameDbContext(options))
    //        //{
    //        //    var repositoryFactory = new RepositoryFactory(context);
    //        //    var commandHandler    = new CommandHandler()
    //        //    var commandsFactory   = new CommandFactory()
    //        //    service.Add("http://sample.com");
    //        //}

    //        //// Use a separate instance of the context to verify correct data was saved to database
    //        //using (var context = new BloggingContext(options))
    //        //{
    //        //    Assert.AreEqual(1, context.Blogs.Count());
    //        //    Assert.AreEqual("http://sample.com", context.Blogs.Single().Url);
    //        //}

    //        // Act

    //        // Assert
    //    }
    //}
}
