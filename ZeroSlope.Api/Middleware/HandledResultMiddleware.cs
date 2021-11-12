using Microsoft.Extensions.Options;
using ZeroSlope.Composition;

namespace ZeroSlope.Api.Middleware
{
	public class HandledResultMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ContainerOptions _apiSettings;

		public HandledResultMiddleware(RequestDelegate next, IOptions<ContainerOptions> options)
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
