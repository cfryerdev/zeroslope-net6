using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Data;
using Serilog;
using ZeroSlope.Infrastructure.Exceptions;
using ZeroSlope.Domain.Base;
using System.Linq;
using ZeroSlope.Domain.Entities;
using Dapper.Contrib.Extensions;
using ZeroSlope.Models.Sample.Responses;
using ZeroSlope.Models.Sample.Requests;

namespace ZeroSlope.Domain.Services
{
	public class SampleService : BaseService
	{
		private IDbConnection Connection;

		public SampleService(IDbConnection connection, IMapper mapper, ILogger logger) : base(mapper, logger)
		{
			Connection = connection;
		}

		public List<SampleResponse> List()
		{
			var collection = Connection.GetAll<SampleEntity>().ToList();
			return Mapper.Map<List<SampleEntity>, List<SampleResponse>>(collection);
		}

		public SampleResponse Read(int id)
		{
			var model = Connection.Get<SampleEntity>(id);
			return Mapper.Map<SampleEntity, SampleResponse>(model);
		}

		public SampleResponse Save(SampleRequest bindingModel)
		{
			var model = Mapper.Map<SampleRequest, SampleEntity>(bindingModel);
			if (model.Id == default(int))
			{
				var identity = (int)Connection.Insert(model);
				model.Id = identity;
			}
			else
			{
				Connection.Update(model);
			}
			return Mapper.Map<SampleEntity, SampleResponse>(model);
		}

		public void Delete(int id)
		{
			var model = Connection.Get<SampleEntity>(id);
			if (model != null)
			{
				Connection.Delete(model);
			}
		}

		public void Delete(SampleRequest bindingModel)
		{
			var model = Mapper.Map<SampleRequest, SampleEntity>(bindingModel);
			Connection.Delete(model);
		}

		public object SampleError()
		{
			throw new HandledException(ExceptionType.General, "This is a sample error.", System.Net.HttpStatusCode.NotAcceptable);
		}
	}
}
