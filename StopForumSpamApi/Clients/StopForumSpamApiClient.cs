using StopForumSpamApi.Common;
using StopForumSpamApi.Configurations;
using StopForumSpamApi.Extensions;
using StopForumSpamApi.Factories;
using StopForumSpamApi.Http;
using StopForumSpamApi.Parameters;
using StopForumSpamApi.Responses;
using System;

namespace StopForumSpamApi.Clients
{
	/// <remarks>
	/// https://www.stopforumspam.com/usage
	/// </remarks>
	public class StopForumSpamApiClient : IStopForumSpamApiClient
	{
		private string _apiKey;

		public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(Constants.TimeoutSeconds);

		public StopForumSpamApiClient()
			 : this(string.Empty)
		{ }

		public StopForumSpamApiClient(string apiKey)
		{
			this._apiKey = apiKey;
			SecurityProtocolConfiguration.ConfigureSecureProtocol();
		}

		public StopForumSpamResponse CheckIp(string ip)
		{
			var response = this.Check(new CheckParameters { Ip = ip });

			return response;
		}

		public StopForumSpamResponse CheckEmail(string email)
		{
			var response = this.Check(new CheckParameters { Email = email });

			return response;
		}

		public StopForumSpamResponse CheckUsername(string username)
		{
			var response = this.Check(new CheckParameters { Username = username });

			return response;
		}

		public StopForumSpamResponse Check(string username, string email, string ip)
		{
			var response = this.Check(new CheckParameters { Username = username, Email = email, Ip = ip });

			return response;
		}

		public StopForumSpamResponse Check(CheckParameters parameters)
		{
			StopForumSpamResponse response = null;

			try
			{
				parameters?.Validate();

				var uriString = string.Concat(Constants.ApiBaseAddress, Constants.GetEndpoint);

				var baseUri = new Uri(uriString, UriKind.Absolute);

				var uriBuilder = new UriBuilder(baseUri)
				{
					Query = parameters?.ToQuery()
				};

				var httpWebRequest = HttpWebRequestFactory.CreateHttpWebRequest(uriBuilder.Uri, HttpMethod.GET, Timeout, Constants.JsonMediaType);

				var json = httpWebRequest.ReadResponseAsString();

				response = json.FromJson<StopForumSpamResponse>();
			}
			catch (Exception ex)
			{
				response = new StopForumSpamResponse { Success = 0, Error = ex.ToString() };
			}

			return response;
		}

		public StopForumSpamResponse AddSpammer(string username, string email, string ip, string evidence = null)
		{
			var response = this.AddSpammer(username, email, ip, this._apiKey, evidence);

			return response;
		}

		public StopForumSpamResponse AddSpammer(string username, string email, string ip, string apikey, string evidence = null)
		{
			var response = this.AddSpammer(new AddSpammerParameters { Username = username, Email = email, Ip = ip, Apikey = apikey, Evidence = evidence });

			return response;
		}

		public StopForumSpamResponse AddSpammer(AddSpammerParameters parameters)
		{
			StopForumSpamResponse response = null;

			try
			{
				parameters?.Validate();

				var uriString = string.Concat(Constants.ApiBaseAddress, Constants.PostEndpoint);

				var uri = new Uri(uriString, UriKind.Absolute);

				var httpWebRequest = HttpWebRequestFactory.CreateHttpWebRequest(uri, HttpMethod.POST, Timeout, Constants.FormUrlEncodedMediaType);

				httpWebRequest.PostData(parameters?.ToQuery());

				var json = httpWebRequest.ReadResponseAsString();

				response = json.FromJson<StopForumSpamResponse>();
			}
			catch (Exception ex)
			{
				response = new StopForumSpamResponse { Success = 0, Error = ex.ToString() };
			}

			return response;

		}

		#region IDisposable Members

		private bool _disposed;

		protected virtual void Dispose(bool disposing)
		{
			if (!this._disposed)
			{
				if (disposing)
				{
					this._apiKey = null;
				}
			}

			this._disposed = true;
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}
