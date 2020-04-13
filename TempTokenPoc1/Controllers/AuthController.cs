using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TempTokenPoc1.interfaces;
using TempTokenPoc1.Filters;
using System.Security.Cryptography;

namespace TempTokenPoc1.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        public  readonly IJWTHandler _jwtHandler;
        public AuthController(IJWTHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }

        [HttpGet("api/GenerateToken")]
        public string  GenerateToken(string userName)
        {
            try
            {
                return _jwtHandler.GetToken(userName);
            }
            catch (Exception e)
            {
               return  $"Exception occurred because of {e.Message}";
            }
        }

        [Auth]
        [HttpPost("api/ValidateToken")]
        public string ValidateToken()
        {
            try
            {
                return "Token validated correctly!!";
            }
            catch (Exception)
            {
                return $"Invalid token please try again !! ";
            }
        }

    }
}
