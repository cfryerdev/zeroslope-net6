using System;
using System.Reflection;

namespace ZeroSlope.Composition.Extensions
{
	public static class TypeExtensions
	{
		public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
		{
			var interfaceTypes = givenType.GetInterfaces();

			foreach (var it in interfaceTypes)
			{
				if (it.GetTypeInfo().IsGenericType && it.GetGenericTypeDefinition() == genericType)
				{
					return true;
				}
			}

			if (givenType.GetTypeInfo().IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
				return true;

			Type baseType = givenType.GetTypeInfo().BaseType;
			if (baseType == null) return false;

			return IsAssignableToGenericType(baseType, genericType);
		}
	}
}