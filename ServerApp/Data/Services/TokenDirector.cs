using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Data.Services
{
    public class TokenDirector
    {   
        public void CreateToken(ITokenBuilder builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            builder
                .AddAudience   ()
                .AddClaims     ()
                .AddExpiry     ()
                .AddIssuer     ()
                .AddSecurityKey();                
        }
    }
}
