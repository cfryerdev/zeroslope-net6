using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroSlope.Models.Authentication.Requests
{
    public class TokenRequest
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
