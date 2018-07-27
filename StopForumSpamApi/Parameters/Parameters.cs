using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StopForumSpamApi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StopForumSpamApi.Parameters
{
	public abstract class Parameters
	{
		[JsonProperty("f")]
		public string Format { get; protected set; }

		[JsonProperty("username")]
		public string Username { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		public abstract void Validate();

		internal string ToQuery()
		{
			var stringBuilder = new StringBuilder();

			var keyValuePairs = this.ToKvp();

			if (keyValuePairs != null && keyValuePairs.Any())
			{
				foreach (var keyValuePair in keyValuePairs.Where(x => !string.IsNullOrWhiteSpace(x.Key) && !string.IsNullOrWhiteSpace(x.Value)))
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append('&');
					}

					stringBuilder.Append(Uri.EscapeDataString(keyValuePair.Key));
					stringBuilder.Append('=');
					stringBuilder.Append(Uri.EscapeDataString(keyValuePair.Value));
				}
			}

			var query = stringBuilder.ToString();

			return query;
		}

		private IEnumerable<KeyValuePair<string, string>> ToKvp()
		{
			IEnumerable<KeyValuePair<string, string>> kvps = null;

			try
			{
				var jsonDictionary = (IDictionary<string, JToken>)JObject.FromObject(this, StopForumSpamConverter.DefaultSerializer.Value);

				kvps = jsonDictionary.Select(kvp => new KeyValuePair<string, string>(kvp.Key, kvp.Value?.Value<string>()));
			}
			catch
			{
				kvps = Enumerable.Empty<KeyValuePair<string, string>>();
			}

			return kvps;
		}
	}
}

