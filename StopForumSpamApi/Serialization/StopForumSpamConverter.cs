using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;
using System.Threading;

namespace StopForumSpamApi.Serialization
{
	internal static class StopForumSpamConverter
	{
		internal static readonly Lazy<JsonSerializer> DefaultSerializer = new Lazy<JsonSerializer>(() => JsonSerializer.CreateDefault(DefaultSettings.Value), LazyThreadSafetyMode.PublicationOnly);

		internal static readonly Lazy<JsonSerializerSettings> DefaultSettings = new Lazy<JsonSerializerSettings>(() => CreateDefaultSettings(), LazyThreadSafetyMode.PublicationOnly);

		private static JsonSerializerSettings CreateDefaultSettings()
		{
			var settings = new JsonSerializerSettings
			{
				MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
				DateParseHandling = DateParseHandling.None,
				Converters =
				{
					new IsoDateTimeConverter
					{
						DateTimeStyles = DateTimeStyles.AssumeUniversal
					}
				}
			};

			return settings;
		}
	}
}
