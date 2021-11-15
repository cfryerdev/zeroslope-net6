using Scrutor;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ZeroSlope.Composition.Installers
{
	public class IDbConnectionInstaller
	{
		private readonly ContainerOptions _options;

		public IDbConnectionInstaller(ContainerOptions options)
		{
			_options = options;
		}

		public void Install(IServiceCollection serviceCollection)
		{
            		var connection = new SqlConnection(_options.Database.SqlConnectionString);
			serviceCollection.AddSingleton<IDbConnection>(connection);
        	}
	}
}
