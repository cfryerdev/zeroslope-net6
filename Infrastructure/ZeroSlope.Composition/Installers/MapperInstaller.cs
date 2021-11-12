using Autofac;
using AutoMapper;
using ZeroSlope.Infrastructure.Interfaces;

namespace ZeroSlope.Composition.Installers
{
	public class MapperInstaller : IBuilder
	{
		private readonly ContainerOptions _options;

		public MapperInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(ContainerBuilder builder)
		{
			var configuration = new MapperConfiguration(cfg =>
			{
				
			});

			var mapper = new Mapper(configuration);

			builder
				.RegisterInstance<IMapper>(mapper)
				.SingleInstance();
		}
	}
}
