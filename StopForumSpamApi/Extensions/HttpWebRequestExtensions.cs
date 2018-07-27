using System;
using System.IO;
using System.Net;
using System.Text;

namespace StopForumSpamApi.Extensions
{
	internal static class HttpWebRequestExtensions
	{
		private static readonly UTF8Encoding UTF8Encoding = new UTF8Encoding();

		public static void PostData(this HttpWebRequest httpWebRequest, string data)
		{
			if (httpWebRequest == null)
			{
				throw new ArgumentNullException(nameof(httpWebRequest));
			}

			var byteArray = UTF8Encoding.GetBytes(data ?? string.Empty);

			httpWebRequest.ContentLength = byteArray.Length;

			var requestStream = httpWebRequest.GetRequestStream();

			requestStream.Write(byteArray, 0, byteArray.Length);
			requestStream.Close();
		}

		public static string ReadResponseAsString(this HttpWebRequest httpWebRequest)
		{
			if (httpWebRequest == null)
			{
				throw new ArgumentNullException(nameof(httpWebRequest));
			}

			using (var webResponse = httpWebRequest.GetResponse())
			using (var responseStream = webResponse.GetResponseStream())
			using (var streamReader = new StreamReader(responseStream, UTF8Encoding))
			{
				return streamReader.ReadToEnd() ?? string.Empty;
			}
		}
	}
}
