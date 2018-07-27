
namespace StopForumSpamApi.Common
{
	internal static class Constants
	{
		public const string ApiBaseAddress = "https://www.stopforumspam.com";

		public const string GetEndpoint = "/api";
		public const string PostEndpoint = "/add";

		public const string Json = "json";

		public const string JsonMediaType = "application/" + Json;
		public const string FormUrlEncodedMediaType = "application/x-www-form-urlencoded";

		public const string ApplicationName = "Stop Forum Spam Api .Net";

		public const double TimeoutSeconds = 5;

		public const string EmptyParameters = "Empty parameters.";
	}
}
