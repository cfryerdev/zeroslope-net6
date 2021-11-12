using Autofac;
using ZeroSlope.Domain;
using ZeroSlope.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ZeroSlope.Composition.Installers
{
	public class ValidatorInstaller : IBuilder
	{
		private readonly ContainerOptions _options;

		public ValidatorInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ContainerBuilder builder)
		{
			var ServiceAssembly = typeof(Init).GetTypeInfo().Assembly;

			builder
				.RegisterAssemblyTypes(ServiceAssembly)
				.Where(t => typeof(IValidateSaveRule<>).IsAssignableFrom(t))
				.AsSelf()
				.InstancePerDependency();

			builder
				.RegisterAssemblyTypes(ServiceAssembly)
				.Where(t => typeof(IValidateDeleteRule<>).IsAssignableFrom(t))
				.AsSelf()
				.InstancePerDependency();
		}
	}
}
