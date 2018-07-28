using System;
using System.Reflection;

namespace StopForumSpamApi.Extensions
{
	internal static class AssemblyExtensions
	{
		public static Version GetVersion()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var assemblyName = assembly.GetName();
			var version = assemblyName.Version;

			return version;
		}

		public static string GetStringVersion()
		{
			var version = GetVersion();
			var stringVersion = version.ToString();

			return stringVersion;
		}
	}
}
