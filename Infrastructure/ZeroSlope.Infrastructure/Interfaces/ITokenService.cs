using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ZeroSlope.Infrastructure.Interfaces
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, string emailAddress);
        string BuildTokenWithClaims(string key, string issuer, Claim[] claims);
    }
}
