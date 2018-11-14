using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using ServerApp.Controllers;
using ServerApp.Data;
using ServerApp.Data.Commands;
using ServerApp.Data.Receivers;
using ServerApp.Data.Repositories;
using ServerApp.Models.Characters.Heroes;
using ServerApp.ViewModels.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Tests.Server
{
    class ServerTests
    {
        private TestServer Server { get; set; }
        private HttpClient Client { get; set; }

        [SetUp]
        public void HeroesControllerTestsOneTimeSetUp()
        {
            this.Server = new TestServer(new WebHostBuilder().UseEnvironment("Development")
                             .UseContentRoot(@"C:\Users\Евгений Мирошниченко\source\repos\HeroesAndDragons\ServerApp")
                             .UseConfiguration(new ConfigurationBuilder()
                                 .SetBasePath(@"C:\Users\Евгений Мирошниченко\source\repos\HeroesAndDragons\ServerApp")
                                 .AddJsonFile("appsettings.json")
                                 .Build())
                             .UseStartup<Startup>());

            this.Client = this.Server.CreateClient();

        }


        #region TEST DATA
        [TestCase("Valid"   )]
        [TestCase("Valid8"  )]
        [TestCase("V8alid8" )]
        #endregion
        public async Task Signup_ValidUserNameFormat_OkObjectResult(string name)
        {
            // Arrange
            var viewModel     = new SignupHeroViewModel() { Name = name };
            var content       = JsonConvert.SerializeObject(viewModel);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Act
            var responce = await this.Client.PostAsync("/api/Account/Signup", stringContent);

            // Assert
            Assert.That(responce.IsSuccessStatusCode, Is.True);
        }

        [Test]
        public async Task Signup_UserIsAlreadyRegistered_BadRequestObjectResult()
        {
            // Arrange
            var viewModel     = new SignupHeroViewModel() { Name = "Valid" };
            var content       = JsonConvert.SerializeObject(viewModel);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var responce = await this.Client.PostAsync("/api/Account/Signup", stringContent);

            // Assert
            Assert.That(responce.IsSuccessStatusCode, Is.True);

            // Act
            responce = await this.Client.PostAsync("/api/Account/Signup", stringContent);

            // Assert
            Assert.That(responce.IsSuccessStatusCode, Is.False);
        }

        #region TEST DATA
        [TestCase("Bad"                   )]
        [TestCase("Veryinvalidnewheroname")]
        [TestCase("invalid"               )]
        [TestCase(" Invalid"              )]
        [TestCase("Invalid "              )]
        [TestCase(" Invalid "             )]
        [TestCase("Invalid,"              )]
        [TestCase("Invalid+"              )]
        [TestCase("Invalid'"              )]
        [TestCase("8nvalid'"              )]
        [TestCase("Invalid_"              )]
        [TestCase("Invalid}"              )]
        #endregion
        public async Task Signup_InvalidUserNameFormat_BadRequestObjectResult(string name)
        {
            // Arrange
            var viewModel = new SignupHeroViewModel() { Name = name };
            var content = JsonConvert.SerializeObject(viewModel);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Act
            var responce = await this.Client.PostAsync("/api/Account/Signup", stringContent);

            Assert.That(responce.IsSuccessStatusCode, Is.False);
        }

        [Test]
        public async Task Signin_HeroIsRegistreted_OkObjectResult()
        {
            // Arrange
            var viewModel     = new SignupHeroViewModel() { Name = "Valid" };
            var content       = JsonConvert.SerializeObject(viewModel);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var responce1       = await this.Client.PostAsync("/api/Account/Signup", stringContent);

            // Assert
            Assert.That(responce1.IsSuccessStatusCode, Is.True);

            // Act
            var responce2 = await this.Client.PostAsync("/api/Account/Signin", stringContent);

            // Assert
            Assert.That(responce2.IsSuccessStatusCode, Is.True);
        }

        [Test]
        public async Task Signin_HeroIsNotRegistreted_OkObjectResult()
        {
            // Arrange
            var viewModel = new SignupHeroViewModel() { Name = "Valid" };
            var content = JsonConvert.SerializeObject(viewModel);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Act
            var responce2 = await this.Client.PostAsync("/api/Account/Signin", stringContent);

            // Assert
            Assert.That(responce2.IsSuccessStatusCode, Is.False);
        }

        [Test]
        public async Task Signin_CreateDragon_OkObjectResult()
        {
            // Arrange
            var viewModel = new SignupHeroViewModel() { Name = "Valid" };
            var content = JsonConvert.SerializeObject(viewModel);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Act
            var responce2 = await this.Client.PostAsync("/api/Account/Signin", stringContent);

            // Assert
            Assert.That(responce2.IsSuccessStatusCode, Is.False);
        }


        [TearDown]
        public void HeroesControllerTestsOneTimeTearDown()
        {
            this.Client.Dispose();
            this.Server.Dispose();
        }
    }
}
