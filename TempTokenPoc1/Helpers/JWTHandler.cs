using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TempTokenPoc1.interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using TempTokenPoc1.Models;
using System.Security.Claims;

namespace TempTokenPoc1.Helpers
{
    public class JWTHandler : IJWTHandler
    {
        public static string hash256Key = "fagbRCyU9ixjcRJLwc3KB9u9N9dY8ZUv6RU3UVt+pQjw0PNaiUb4Rl4Q2KHQjz/WcZsvuR5hCEskdjjtJwDMNA==";
        private readonly Keys _keys;
        public JWTHandler(IOptions<Keys> keys)
        {
            _keys = keys.Value;
        }
        public string GetToken(string userName)
        {
            //var hash256Key = new HMACSHA256();
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = _keys.IssuerID,
                Expires = DateTime.UtcNow.AddMinutes(_keys.ExpirationTime),
                Subject=new System.Security.Claims.ClaimsIdentity(new[] { 
                new Claim(ClaimTypes.Name,_keys.UserName),
                new Claim(ClaimTypes.Email,_keys.ClientID)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Convert.FromBase64String(hash256Key)),
            SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        
    }
}
