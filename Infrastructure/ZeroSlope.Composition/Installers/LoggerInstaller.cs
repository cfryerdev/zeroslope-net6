using Scrutor;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using ZeroSlope.Infrastructure.Interfaces;

namespace ZeroSlope.Composition.Installers
{
	public class LoggerInstaller
	{
		private readonly ContainerOptions _options;

		public LoggerInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(IServiceCollection serviceCollection)
		{
			var logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
			serviceCollection.AddSingleton<ILogger>(logger);
		}
	}
}
