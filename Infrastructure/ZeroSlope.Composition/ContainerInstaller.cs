using Autofac;
using Autofac.Core;
using ZeroSlope.Infrastructure.Interfaces;
using ZeroSlope.Composition.Installers;
using System;
using System.Collections.Generic;

namespace ZeroSlope.Composition
{
	public class ContainerInstaller
	{
		private readonly ContainerOptions _options;

		public ContainerInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public ContainerBuilder Install()
		{
			var builder = Blank();

			new LoggerInstaller(_options).Install(builder);
			new IDbConnectionInstaller(_options).Install(builder);
			new MapperInstaller(_options).Install(builder);
			new ProcessorInstaller(_options).Install(builder);
			new ValidatorInstaller(_options).Install(builder);
			new ServiceInstaller(_options).Install(builder);

			return builder;
		}

		public ContainerBuilder Blank()
		{
			return new ContainerBuilder();
		}

		public ContainerBuilder Build(List<IBuilder> installers)
		{
			var builder = Blank();
			foreach (var installer in installers)
			{
				installer.Install(builder);
			}
			return builder;
		}
	}
}
