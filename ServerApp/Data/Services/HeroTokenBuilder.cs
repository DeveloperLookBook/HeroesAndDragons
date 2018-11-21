using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ServerApp.Models.Characters.Heroes;

namespace ServerApp.Data.Services
{
    public class HeroTokenBuilder : TokenBuilder
    {
        private IHero Hero { get; set; }


        public HeroTokenBuilder(IConfiguration configuration, IHero hero) 
            : base(configuration)
        {
            this.Hero = hero ?? throw new ArgumentNullException(nameof(hero));
        }


        override public ITokenBuilder AddAudience   ()
        {
            return base.AddAudience(this.Configuration["Jwt:Audience"]);
        }
        override public ITokenBuilder AddClaims     ()
        {
            return base.AddClaims(new List<Claim>()
            {
                new Claim("Id", this.Hero.Id.ToString(), typeof(int).ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, this.Hero.Name)
            });
        }
        override public ITokenBuilder AddExpiry     ()
        {
            return base.AddExpiry(120);
        }
        override public ITokenBuilder AddIssuer     ()
        {
            return base.AddIssuer(this.Configuration["Jwt:Issuer"]);
        }
        override public ITokenBuilder AddSecurityKey()
        {
            return base.AddSecurityKey(this.Configuration["Jwt:Key"]);
        }
    }
}
