using System;
using System.Collections.Generic;
using System.Text;

namespace ZeroSlope.Infrastructure.Exceptions
{
	public class HandledResponseError
	{
		public string Code { get; set; }
		public string Type { get; set; }
		public string Message { get; set; }
	}
}
