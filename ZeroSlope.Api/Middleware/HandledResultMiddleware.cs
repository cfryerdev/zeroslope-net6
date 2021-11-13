using Microsoft.Extensions.Options;
using System.Text.Json;
using ZeroSlope.Composition;
using ZeroSlope.Infrastructure.Exceptions;

namespace ZeroSlope.Api.Middleware
{
	public class HandledResultMiddleware
	{
		private readonly RequestDelegate _next;

		public HandledResultMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
            {
				await _next.Invoke(context);
			}
			catch (Exception ex)
            {
				var response = context.Response;
				response.ContentType = "application/json";
				var error = new HandledResult<Exception>(ex).HandleException();
				var result = JsonSerializer.Serialize(error);
				await response.WriteAsync(result);
			}
		}
	}
}
