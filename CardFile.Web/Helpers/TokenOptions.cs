using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFile.Web.Helpers
{
    public class TokenOptions
    {

        public const string Issuer = "BackendApplication";
        public const string Audience = "FrontApplication";
        public const string Key = "simplysupersecret2022year";
        public const int LifeTime = 5000;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
