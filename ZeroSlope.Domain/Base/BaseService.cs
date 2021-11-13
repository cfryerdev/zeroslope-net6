using AutoMapper;
using ZeroSlope.Infrastructure.Interfaces;
using System.Data;
using System;
using Serilog;

namespace ZeroSlope.Domain.Base
{
	public abstract class BaseService : IService
	{
		public BaseService(IMapper mapper, ILogger logger)
		{
			Mapper = mapper;
			Logger = logger;
		}

		public IMapper Mapper { get; set; }

		public ILogger Logger { get; set; }
	}
}
