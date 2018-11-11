using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServerApp.Extencions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServerApp.Data.Services
{
    public abstract class TokenBuilder : ITokenBuilder
    {
        private   SecurityKey    SecurityKey   { get; set; }
        private   string         Issuer        { get; set; } = string.Empty;
        private   string         Audience      { get; set; } = string.Empty;
        private   int            LifeTime      { get; set; } = 10;
        private   List<Claim>    Claims        => new List<Claim>();
        protected IConfiguration Configuration { get; }


        public TokenBuilder(IConfiguration configuration) => this.Configuration = configuration;


        protected TokenBuilder AddSecurityKey(string             secretKey      )
        {
            if (secretKey.IsNull      ()) { throw new ArgumentNullException(nameof(secretKey)); }
            if (secretKey.IsEmpty     ()) { throw new ArgumentException("Mustn't be empty."     , nameof(secretKey)); }
            if (secretKey.IsWhiteSpace()) { throw new ArgumentException("Mustn't be whitespace.", nameof(secretKey)); }

            this.SecurityKey = JwtSecurityKeyFactory.Create(secretKey);

            return this;
        }
        protected TokenBuilder AddIssuer     (string             issuer         )
        {
            if (issuer.IsNull      ()) { throw new ArgumentNullException(nameof(issuer)); }
            if (issuer.IsEmpty     ()) { throw new ArgumentException("Mustn't be empty."     , nameof(issuer)); }
            if (issuer.IsWhiteSpace()) { throw new ArgumentException("Mustn't be whitespace.", nameof(issuer)); }

            this.Issuer = issuer;

            return this;
        }
        protected TokenBuilder AddAudience   (string             audience       )
        {
            if (audience.IsNull      ()) { throw new ArgumentNullException(nameof(audience)); }
            if (audience.IsEmpty     ()) { throw new ArgumentException("Mustn't be empty."     , nameof(audience)); }
            if (audience.IsWhiteSpace()) { throw new ArgumentException("Mustn't be whitespace.", nameof(audience)); }

            this.Audience = audience;

            return this;
        }
        protected TokenBuilder AddExpiry     (int                expiryInMinutes)
        {
            this.LifeTime = expiryInMinutes;

            return this;
        }
        protected TokenBuilder AddClaims     (IEnumerable<Claim> claims         )
        {
            if (claims is null) { throw new ArgumentNullException(nameof(claims)); }

            this.Claims.AddRange(claims);

            return this;
        }

        virtual  public string  Build         ()
        {
            var jwtToken = new JwtSecurityToken(
                              issuer            : this.Issuer,
                              audience          : this.Audience,
                              notBefore         : DateTime.UtcNow,
                              claims            : this.Claims,
                              expires           : DateTime.UtcNow.AddMinutes(this.LifeTime),
                              signingCredentials: new SigningCredentials(
                                                        this.SecurityKey,
                                                        SecurityAlgorithms.HmacSha256));

            var encodedJwtToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return encodedJwtToken;
        }


        abstract public ITokenBuilder AddSecurityKey();
        abstract public ITokenBuilder AddIssuer     ();
        abstract public ITokenBuilder AddAudience   ();
        abstract public ITokenBuilder AddExpiry     ();
        abstract public ITokenBuilder AddClaims     ();
    }
}
