using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempTokenPoc1.Models
{
    public class Keys
    {
        public  int ExpirationTime { get; set; }
        public  string UserName { get; set; }
        public  string ClientID { get; set; }
        public  string IssuerID { get; set; }
    }
}
