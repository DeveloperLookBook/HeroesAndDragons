using ServerApp.Models.Characters.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServerApp.Data.Services
{
    public class HeroClaimsFactory
    {
        public List<Claim> Create(IHero hero)
        {
            return new List<Claim>()
            {
                new Claim("Id", hero.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, hero.Name),
            };
        }
    }
}
