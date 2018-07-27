using Newtonsoft.Json;
using StopForumSpamApi.Serialization;

namespace StopForumSpamApi.Extensions
{
	public static class ObjectExtensions
	{
		public static string ToJson<T>(this T self) where T : class => JsonConvert.SerializeObject(self, StopForumSpamConverter.DefaultSettings.Value);		
	}
}
