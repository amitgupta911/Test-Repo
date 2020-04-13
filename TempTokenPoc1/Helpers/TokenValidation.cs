using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TempTokenPoc1.Helpers
{
    public class TokenValidation
    {
        private const string hash256Key= "fagbRCyU9ixjcRJLwc3KB9u9N9dY8ZUv6RU3UVt+pQjw0PNaiUb4Rl4Q2KHQjz/WcZsvuR5hCEskdjjtJwDMNA==";
        public static bool ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return false;



                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(hash256Key))
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                var identity = principal.Identity as ClaimsIdentity;

                if (identity == null)
                    return false;

                if (!identity.IsAuthenticated)
                    return false;

                var username = identity.FindFirst(ClaimTypes.Name)?.Value;
                var email = identity.FindFirst(ClaimTypes.Email)?.Value;


                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
                    return false;

                if (username.Equals("Amit") && email.Equals("amit.gupta@airbus.com"))
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
