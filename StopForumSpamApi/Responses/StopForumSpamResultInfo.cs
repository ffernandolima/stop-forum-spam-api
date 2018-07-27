using Newtonsoft.Json;
using System;

namespace StopForumSpamApi.Responses
{
	public class StopForumSpamResultInfo
	{
		[JsonProperty("lastseen")]
		public DateTimeOffset? LastSeen { get; set; }

		[JsonProperty("frequency")]
		public long? Frequency { get; set; }

		[JsonProperty("appears")]
		public long? Appears { get; set; }

		[JsonProperty("confidence")]
		public double? Confidence { get; set; }

		[JsonProperty("delegated")]
		public string Delegated { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("asn")]
		public long? Asn { get; set; }
	}
}
