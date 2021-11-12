using Autofac;
using ZeroSlope.Domain;
using System.Reflection;
using ZeroSlope.Domain.Base;
using ZeroSlope.Infrastructure.Interfaces;

namespace ZeroSlope.Composition.Installers
{
	public class ServiceInstaller : IBuilder
	{
		private readonly ContainerOptions _options;

		public ServiceInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ContainerBuilder builder)
		{
			var ServiceAssembly = typeof(Init).GetTypeInfo().Assembly;

			builder
				.RegisterAssemblyTypes(ServiceAssembly)
				.Where(t => typeof(BaseService).IsAssignableFrom(t))
				.AsSelf()
				.InstancePerDependency();
		}
	}
}
