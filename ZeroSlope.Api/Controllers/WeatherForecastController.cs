using Microsoft.AspNetCore.Mvc;

namespace ZeroSlope.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{

		//	private readonly ILogger<WeatherForecastController> _logger;

		//	public WeatherForecastController(ILogger<WeatherForecastController> logger)
		//	{
		//		_logger = logger;
		//	}

		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<object> Get()
		{
			return new List<object>();
		}
	}
}