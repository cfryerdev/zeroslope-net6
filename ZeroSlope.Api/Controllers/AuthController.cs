using ZeroSlope.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ZeroSlope.Domain.BindingModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using ZeroSlope.Domain.BindingModels.Response;
using ZeroSlope.Domain.BindingModels.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using ZeroSlope.Composition;

namespace ZeroSlope.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ContainerOptions _options;

        public AuthController(IOptions<ContainerOptions> options)
        {
            _options = options.Value;
        }
        

        /// <summary>
        /// Generates a JWT Token based on a client secret and client id
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("authenticate")]
        [AllowAnonymous]
		public TokenResponse Authenticate([FromBody] TokenRequest request)
		{
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Token.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, request.ClientId.ToString()),
                    //new Claim(ClaimTypes.Role, "Administrator")
                }),
                Expires = DateTime.UtcNow.AddMinutes(_options.Token.ExpirationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenResponse() { Token = tokenHandler.WriteToken(token) };
        }

	}
}
