using Autofac;
using ZeroSlope.Domain;
using ZeroSlope.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ZeroSlope.Composition.Installers
{
	public class ProcessorInstaller : IBuilder
	{
		private readonly ContainerOptions _options;

		public ProcessorInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ContainerBuilder builder)
		{
			var ServiceAssembly = typeof(Init).GetTypeInfo().Assembly;

			builder
				.RegisterAssemblyTypes(ServiceAssembly)
				.Where(t => typeof(IBeforeCreateLogicProcessor<>).IsAssignableFrom(t))
				.AsSelf()
				.InstancePerDependency();

			builder
				.RegisterAssemblyTypes(ServiceAssembly)
				.Where(t => typeof(IAfterCreateLogicProcessor<>).IsAssignableFrom(t))
				.AsSelf()
				.InstancePerDependency();

			builder
				.RegisterAssemblyTypes(ServiceAssembly)
				.Where(t => typeof(IBeforeUpdateLogicProcessor<>).IsAssignableFrom(t))
				.AsSelf()
				.InstancePerDependency();

			builder
				.RegisterAssemblyTypes(ServiceAssembly)
				.Where(t => typeof(IAfterUpdateLogicProcessor<>).IsAssignableFrom(t))
				.AsSelf()
				.InstancePerDependency();

			builder
				.RegisterAssemblyTypes(ServiceAssembly)
				.Where(t => typeof(IBeforeDeleteLogicProcessor<>).IsAssignableFrom(t))
				.AsSelf()
				.InstancePerDependency();

			builder
				.RegisterAssemblyTypes(ServiceAssembly)
				.Where(t => typeof(IAfterDeleteLogicProcessor<>).IsAssignableFrom(t))
				.AsSelf()
				.InstancePerDependency();
		}
	}
}
