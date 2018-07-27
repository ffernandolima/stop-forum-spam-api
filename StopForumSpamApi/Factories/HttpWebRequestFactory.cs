using StopForumSpamApi.Common;
using StopForumSpamApi.Http;
using System;
using System.Net;

namespace StopForumSpamApi.Factories
{
	internal static class HttpWebRequestFactory
	{
		private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(Constants.TimeoutSeconds);

		public static HttpWebRequest CreateHttpWebRequest(Uri uri, HttpMethod httpMethod, string contentType = null)
		{
			var httpWebRequest = CreateHttpWebRequest(uri, httpMethod, Timeout, contentType);

			return httpWebRequest;
		}

		public static HttpWebRequest CreateHttpWebRequest(Uri uri, HttpMethod httpMethod, TimeSpan timeout, string contentType = null)
		{
			var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);

			httpWebRequest.Method = httpMethod.ToString();
			httpWebRequest.Timeout = (int)timeout.TotalMilliseconds;
			httpWebRequest.UserAgent = Constants.ApplicationName;

			if (!string.IsNullOrWhiteSpace(contentType))
			{
				httpWebRequest.ContentType = contentType;
			}

			return httpWebRequest;
		}
	}
}
