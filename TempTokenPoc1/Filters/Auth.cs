using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TempTokenPoc1.Helpers;
using TempTokenPoc1.interfaces;

namespace TempTokenPoc1.Filters
{
    public class Auth :Attribute, IAuthorizationFilter
    {
        
      

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue("Authorization",out StringValues headerValue);
            var result=headerValue.FirstOrDefault();
            string token = result.Replace("Bearer ", "");
            if (TokenValidation.ValidateToken(token))
            {

            }
            else
            {
                throw new Exception();
            }


        }
    }
}
