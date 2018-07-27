using Newtonsoft.Json;
using StopForumSpamApi.Serialization;

namespace StopForumSpamApi.Extensions
{
	public static class StringExtensions
	{
		public static T FromJson<T>(this string json) where T : class => JsonConvert.DeserializeObject<T>(json, StopForumSpamConverter.DefaultSettings.Value);
	}
}
