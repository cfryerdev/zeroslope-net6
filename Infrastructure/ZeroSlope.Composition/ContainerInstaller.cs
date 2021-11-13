using Scrutor;
using ZeroSlope.Infrastructure.Interfaces;
using ZeroSlope.Composition.Installers;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace ZeroSlope.Composition
{
	public class ContainerInstaller
	{
		private readonly ContainerOptions _options;

		public ContainerInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(IServiceCollection serviceCollection)
		{
			new LoggerInstaller(_options).Install(serviceCollection);
			new IDbConnectionInstaller(_options).Install(serviceCollection);
			new MapperInstaller(_options).Install(serviceCollection);

			serviceCollection.Scan(scan => new ServiceInstaller(_options).Install(scan));
		}
	}
}
