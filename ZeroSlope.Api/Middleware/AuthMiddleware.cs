using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using ZeroSlope.Composition;

namespace ZeroSlope.Api.Middleware
{
	public class AuthMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ContainerOptions _apiSettings;

		public AuthMiddleware(RequestDelegate next, IOptions<ContainerOptions> options)
		{
			_next = next;
			_apiSettings = options.Value;
		}

		public async Task Invoke(HttpContext context)
		{
			await _next.Invoke(context);
		}
	}
}
