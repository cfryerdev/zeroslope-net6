using ZeroSlope.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using ZeroSlope.Composition;
using ZeroSlope.Models.Authentication.Requests;
using ZeroSlope.Models.Authentication.Responses;

namespace ZeroSlope.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly ContainerOptions _settings;

        public AuthController(AuthService authService, ContainerOptions settings)
        {
            _authService = authService;
            _settings = settings;
        }


        /// <summary>
        /// Generates a JWT Token based on a EmailAddress and password
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("authenticate")]
        [AllowAnonymous]
		public TokenResponse Authenticate([FromBody] TokenRequest request)
		{
            return new TokenResponse()
            {
                Token = _authService.Login(_settings.Token.Secret, _settings.Token.Issuer, request.EmailAddress, request.Password)
            };
        }

	}
}
