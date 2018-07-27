using System.Net;

namespace StopForumSpamApi.Configurations
{
	internal static class SecurityProtocolConfiguration
	{
		public static void ConfigureSecureProtocol()
		{
			ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
			ServicePointManager.SecurityProtocol &= ~SecurityProtocolType.Ssl3;
		}
	}
}
