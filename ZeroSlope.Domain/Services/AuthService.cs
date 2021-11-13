using AutoMapper;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroSlope.Domain.Base;
using ZeroSlope.Infrastructure.Interfaces;

namespace ZeroSlope.Domain.Services
{
    public class AuthService : BaseService
    {
        private readonly ITokenService _tokenService;

        public AuthService(ITokenService tokenService, IMapper mapper, ILogger logger) : base(mapper, logger)
        {
            _tokenService = tokenService;
        }

        public string Login(string secret, string issuer, string emailAddress, string password)
        {
            // Do some authentication with username and password, if valid, create
            // the token below, for this sample, we will just return a token.

            return _tokenService.BuildToken(secret, issuer, emailAddress);
        }
    }
}
