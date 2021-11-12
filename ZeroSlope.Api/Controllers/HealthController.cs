using ZeroSlope.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ZeroSlope.Domain.BindingModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace ZeroSlope.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class HealthController : ControllerBase
	{
		/// <summary>
		/// Returns the health state of the service.
		/// </summary>
		/// <returns></returns>
		[HttpGet, Route("")]
        [AllowAnonymous]
		public ActionResult List()
		{
            return new OkResult();
		}

	}
}
