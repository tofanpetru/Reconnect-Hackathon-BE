using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyMaker.Application.Configuration
{
    public class AuthConfiguration
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int TokenLifetime { get; set; }
        
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            if (SecretKey == null)
            {
                throw new ArgumentNullException("Login failed - invalid key");
            }

            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        }
    }
}
