using Autofac;

namespace ZeroSlope.Infrastructure.Interfaces
{
	public interface IBuilder
	{
		void Install(ContainerBuilder builder);
	}
}
