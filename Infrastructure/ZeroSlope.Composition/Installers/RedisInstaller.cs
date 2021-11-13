using Scrutor;
using ZeroSlope.Infrastructure.Exceptions;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using ZeroSlope.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ZeroSlope.Composition.Installers
{
	public class RedisInstaller
	{
		private readonly ContainerOptions _options;

		public RedisInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(IServiceCollection serviceCollection)
		{
            try
            {
                var connection = ConnectionMultiplexer.Connect($"{_options.Caching.RedisHost}:{_options.Caching.RedisPort}");
                var db = connection.GetDatabase(_options.Caching.RedisDatabaseId);
                serviceCollection.AddSingleton<IConnectionMultiplexer>(connection);
                serviceCollection.AddSingleton<IDatabase>(db);
            }
            catch (Exception ex)
            {
                throw new HandledException(ExceptionType.Service, ex.Message);
            }
        }
	}
}
