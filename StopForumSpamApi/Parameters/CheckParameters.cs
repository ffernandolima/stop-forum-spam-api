using Newtonsoft.Json;
using StopForumSpamApi.Common;
using System;
using System.Linq;

namespace StopForumSpamApi.Parameters
{
	public class CheckParameters : Parameters
	{
		public CheckParameters()
		{
			this.Format = Constants.Json;
		}

		[JsonProperty("ip")]
		public string Ip { get; set; }

		public override void Validate()
		{
			var parameters = new[]
			{
				this.Username,
				this.Email,
				this.Ip
			};

			if (parameters.All(parameter => string.IsNullOrWhiteSpace(parameter)))
			{
				throw new ArgumentNullException(nameof(parameters), Constants.EmptyParameters);
			}
		}
	}
}
