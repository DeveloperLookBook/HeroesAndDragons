using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Data.Services
{
    public class JwtSecurityKeyFactory
    {
        public static SymmetricSecurityKey Create(string secretKey)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
        }
    }
}
