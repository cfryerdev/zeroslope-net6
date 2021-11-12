using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Data;
using Serilog;
using ZeroSlope.Infrastructure.Exceptions;
using ZeroSlope.Domain.Base;
using System.Linq;
using ZeroSlope.Domain.BindingModels;
using ZeroSlope.Domain.Entities;
using Dapper.Contrib.Extensions;

namespace ZeroSlope.Domain.Services
{
	public class SampleService : BaseService
	{
		private IDbConnection Connection;

		public SampleService(IDbConnection connection, IMapper mapper, ILogger logger) : base(mapper, logger)
		{
			Connection = connection;
		}

		public List<SampleEntityBindingModel> List()
		{
			var collection = Connection.GetAll<SampleEntity>().ToList();
			return Mapper.Map<List<SampleEntity>, List<SampleEntityBindingModel>>(collection);
		}

		public SampleEntityBindingModel Read(int id)
		{
			var model = Connection.Get<SampleEntity>(id);
			return Mapper.Map<SampleEntity, SampleEntityBindingModel>(model);
		}

		public SampleEntityBindingModel Save(SampleEntityBindingModel bindingModel)
		{
			var model = Mapper.Map<SampleEntityBindingModel, SampleEntity>(bindingModel);
			if (model.Id == default(int))
			{
				var identity = (int)Connection.Insert(model);
				model.Id = identity;
			}
			else
			{
				Connection.Update(model);
			}
			return Mapper.Map<SampleEntity, SampleEntityBindingModel>(model);
		}

		public void Delete(int id)
		{
			var model = Connection.Get<SampleEntity>(id);
			if (model != null)
			{
				Connection.Delete(model);
			}
		}

		public void Delete(SampleEntityBindingModel bindingModel)
		{
			var model = Mapper.Map<SampleEntityBindingModel, SampleEntity>(bindingModel);
			Connection.Delete(model);
		}

		public object SampleError()
		{
			throw new HandledException(ExceptionType.General, "This is a sample error.", System.Net.HttpStatusCode.NotAcceptable);
		}
	}
}
