using NUnit.Framework;
using ServerApp.Models.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.Tests.Models.Heroes
{
    class HeroTests
    {
        IHero Hero { get; set; }

        [SetUp]
        public void SetUpTests()
        {
            this.Hero = new Hero();
        }

        [TestCase(null, ExpectedResult = typeof(ArgumentNullException))]
        public object Name(string value)
        {
            try
            {
                return (this.Hero.Name = value);
            }
            catch (ArgumentNullException exc)
            {
                return exc.GetType();
            }
        }
    }
}
