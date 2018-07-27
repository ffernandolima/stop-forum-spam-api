using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace StopForumSpamApi.Responses
{
	public class StopForumSpamResponse
	{
		[JsonProperty("success")]
		public long? Success { get; set; }

		[JsonProperty("username")]
		public StopForumSpamResultInfo Username { get; set; }

		[JsonProperty("email")]
		public StopForumSpamResultInfo Email { get; set; }

		[JsonProperty("ip")]
		public StopForumSpamResultInfo Ip { get; set; }

		[JsonProperty("error")]
		public string Error { get; set; }

		[JsonIgnore]
		public bool Successful => this.Success.GetValueOrDefault() > 0;

		[JsonIgnore]
		public float HigherConfidenceRate => this.Confidences.Max(confidence => (float)confidence);

		[JsonIgnore]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IEnumerable<double> Confidences => new[] { this.Username?.Confidence, this.Email?.Confidence, this.Ip?.Confidence }.Select(confidence => confidence.GetValueOrDefault());

		public bool IsSpam(int rate) => this.Confidences.Any(confidence => confidence >= rate);
	}
}
