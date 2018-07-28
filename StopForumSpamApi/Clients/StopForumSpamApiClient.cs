using StopForumSpamApi.Common;
using StopForumSpamApi.Configurations;
using StopForumSpamApi.Extensions;
using StopForumSpamApi.Factories;
using StopForumSpamApi.Http;
using StopForumSpamApi.Parameters;
using StopForumSpamApi.Responses;
using StopForumSpamApi.Threading;
using System;
using System.Threading;
using System.Threading.Tasks;

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

		public StopForumSpamResponse CheckIp(string ip) => this.Check(new CheckParameters { Ip = ip });

		public Task<StopForumSpamResponse> CheckIpAsync(string ip) => this.CheckIpAsync(ip, CancellationTokenFactory.Token());

		public Task<StopForumSpamResponse> CheckIpAsync(string ip, CancellationToken cancellationToken)
		{
			if (cancellationToken == null)
			{
				cancellationToken = CancellationTokenFactory.Token();
			}

			var task = Task.Factory.StartNew(() => this.CheckIp(ip), cancellationToken);

			return task;
		}

		public StopForumSpamResponse CheckEmail(string email) => this.Check(new CheckParameters { Email = email });

		public Task<StopForumSpamResponse> CheckEmailAsync(string email) => this.CheckEmailAsync(email, CancellationTokenFactory.Token());

		public Task<StopForumSpamResponse> CheckEmailAsync(string email, CancellationToken cancellationToken)
		{
			if (cancellationToken == null)
			{
				cancellationToken = CancellationTokenFactory.Token();
			}

			var task = Task.Factory.StartNew(() => this.CheckEmail(email), cancellationToken);

			return task;
		}

		public StopForumSpamResponse CheckUsername(string username) => this.Check(new CheckParameters { Username = username });

		public Task<StopForumSpamResponse> CheckUsernameAsync(string username) => this.CheckUsernameAsync(username, CancellationTokenFactory.Token());

		public Task<StopForumSpamResponse> CheckUsernameAsync(string username, CancellationToken cancellationToken)
		{
			if (cancellationToken == null)
			{
				cancellationToken = CancellationTokenFactory.Token();
			}

			var task = Task.Factory.StartNew(() => this.CheckUsername(username), cancellationToken);

			return task;
		}

		public StopForumSpamResponse Check(string username, string email, string ip) => this.Check(new CheckParameters { Username = username, Email = email, Ip = ip });

		public Task<StopForumSpamResponse> CheckAsync(string username, string email, string ip) => this.CheckAsync(username, email, ip, CancellationTokenFactory.Token());

		public Task<StopForumSpamResponse> CheckAsync(string username, string email, string ip, CancellationToken cancellationToken)
		{
			if (cancellationToken == null)
			{
				cancellationToken = CancellationTokenFactory.Token();
			}

			var task = Task.Factory.StartNew(() => this.Check(username, email, ip), cancellationToken);

			return task;
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

				var httpWebRequest = HttpWebRequestFactory.CreateHttpWebRequest(uriBuilder.Uri, HttpMethod.GET, this.Timeout, Constants.JsonMediaType);

				var json = httpWebRequest.ReadResponseAsString();

				response = json.FromJson<StopForumSpamResponse>();
			}
			catch (Exception ex)
			{
				response = new StopForumSpamResponse { Success = 0, Error = ex.ToString() };
			}

			return response;
		}

		public Task<StopForumSpamResponse> CheckAsync(CheckParameters parameters) => this.CheckAsync(parameters, CancellationTokenFactory.Token());

		public Task<StopForumSpamResponse> CheckAsync(CheckParameters parameters, CancellationToken cancellationToken)
		{
			if (cancellationToken == null)
			{
				cancellationToken = CancellationTokenFactory.Token();
			}

			var task = Task.Factory.StartNew(() => this.Check(parameters), cancellationToken);

			return task;
		}

		public StopForumSpamResponse AddSpammer(string username, string email, string ip, string evidence = null) => this.AddSpammer(username, email, ip, this._apiKey, evidence);

		public Task<StopForumSpamResponse> AddSpammerAsync(string username, string email, string ip, string evidence = null) => this.AddSpammerAsync(username, email, ip, CancellationTokenFactory.Token(), evidence);

		public Task<StopForumSpamResponse> AddSpammerAsync(string username, string email, string ip, CancellationToken cancellationToken, string evidence = null)
		{
			if (cancellationToken == null)
			{
				cancellationToken = CancellationTokenFactory.Token();
			}

			var task = Task.Factory.StartNew(() => this.AddSpammer(username, email, ip, evidence), cancellationToken);

			return task;
		}

		public StopForumSpamResponse AddSpammer(string username, string email, string ip, string apikey, string evidence = null) => this.AddSpammer(new AddSpammerParameters { Username = username, Email = email, Ip = ip, Apikey = apikey, Evidence = evidence });

		public Task<StopForumSpamResponse> AddSpammerAsync(string username, string email, string ip, string apikey, string evidence = null) => this.AddSpammerAsync(username, email, ip, apikey, CancellationTokenFactory.Token(), evidence);

		public Task<StopForumSpamResponse> AddSpammerAsync(string username, string email, string ip, string apikey, CancellationToken cancellationToken, string evidence = null)
		{
			if (cancellationToken == null)
			{
				cancellationToken = CancellationTokenFactory.Token();
			}

			var task = Task.Factory.StartNew(() => this.AddSpammer(username, email, ip, apikey, evidence), cancellationToken);

			return task;
		}

		public StopForumSpamResponse AddSpammer(AddSpammerParameters parameters)
		{
			StopForumSpamResponse response = null;

			try
			{
				parameters?.Validate();

				var uriString = string.Concat(Constants.ApiBaseAddress, Constants.PostEndpoint);

				var uri = new Uri(uriString, UriKind.Absolute);

				var httpWebRequest = HttpWebRequestFactory.CreateHttpWebRequest(uri, HttpMethod.POST, this.Timeout, Constants.FormUrlEncodedMediaType);

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

		public Task<StopForumSpamResponse> AddSpammerAsync(AddSpammerParameters parameters) => this.AddSpammerAsync(parameters, CancellationTokenFactory.Token());

		public Task<StopForumSpamResponse> AddSpammerAsync(AddSpammerParameters parameters, CancellationToken cancellationToken)
		{
			if (cancellationToken == null)
			{
				cancellationToken = CancellationTokenFactory.Token();
			}

			var task = Task.Factory.StartNew(() => this.AddSpammer(parameters), cancellationToken);

			return task;
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
