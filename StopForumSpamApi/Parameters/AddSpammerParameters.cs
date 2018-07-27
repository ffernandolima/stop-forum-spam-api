using Newtonsoft.Json;
using StopForumSpamApi.Common;
using System;
using System.Linq;

namespace StopForumSpamApi.Parameters
{
	public class AddSpammerParameters : Parameters
	{
		[JsonProperty("ip_addr")]
		public string Ip { get; set; }

		[JsonProperty("evidence")]
		public string Evidence { get; set; }

		[JsonProperty("api_key")]
		public string Apikey { get; set; }

		public override void Validate()
		{
			var parameters = new[]
			{
				this.Username,
				this.Email,
				this.Ip,
				this.Evidence,
				this.Apikey
			};

			if (parameters.All(parameter => string.IsNullOrWhiteSpace(parameter)))
			{
				throw new ArgumentNullException(nameof(parameters), Constants.EmptyParameters);
			}
		}
	}
}
