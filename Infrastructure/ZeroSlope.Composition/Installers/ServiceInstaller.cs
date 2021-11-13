using Scrutor;
using ZeroSlope.Domain;
using System.Reflection;
using ZeroSlope.Domain.Base;
using ZeroSlope.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ZeroSlope.Composition.Installers
{
	public class ServiceInstaller
	{
		private readonly ContainerOptions _options;

		public ServiceInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ITypeSourceSelector scan)
		{
			var ServiceAssembly = typeof(Init).GetTypeInfo().Assembly;
			scan.FromAssemblyOf<ZeroSlope.Domain.Init>()
				.AddClasses(classes => classes.AssignableTo<ZeroSlope.Domain.Base.BaseService>())
				.AsSelf()
				.WithScopedLifetime();
		}
	}
}
