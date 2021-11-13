using Scrutor;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ZeroSlope.Infrastructure.Interfaces;

namespace ZeroSlope.Composition.Installers
{
	public class MapperInstaller
	{
		private readonly ContainerOptions _options;

		public MapperInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(IServiceCollection serviceCollection)
		{
			var configuration = new MapperConfiguration(cfg =>{});
			var mapper = new Mapper(configuration);
			serviceCollection.AddSingleton<IMapper>(mapper);
		}
	}
}
