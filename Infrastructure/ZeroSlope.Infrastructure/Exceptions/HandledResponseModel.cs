using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ZeroSlope.Infrastructure.Exceptions
{
	public class HandledResponseModel
	{
		public HandledResponseModel(HttpStatusCode status = HttpStatusCode.BadRequest)
		{
			StatusCode = (int)status;
			Exceptions = new List<HandledResponseError>();
		}

		public int StatusCode { get; set; }

		public List<HandledResponseError> Exceptions { get; set; }

	}
}
