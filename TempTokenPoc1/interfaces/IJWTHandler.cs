using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempTokenPoc1.interfaces
{
    public interface IJWTHandler
    {
        string GetToken(string userName);

        
    }
}
