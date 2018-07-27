using StopForumSpamApi.Parameters;
using StopForumSpamApi.Responses;
using System;

namespace StopForumSpamApi.Clients
{
	/// <remarks>
	/// https://www.stopforumspam.com/usage
	/// </remarks>
	public interface IStopForumSpamApiClient : IDisposable
	{
		TimeSpan Timeout { get; set; }

		StopForumSpamResponse CheckIp(string ip);
		StopForumSpamResponse CheckEmail(string email);
		StopForumSpamResponse CheckUsername(string username);
		StopForumSpamResponse Check(string username, string email, string ip);
		StopForumSpamResponse Check(CheckParameters parameters);

		StopForumSpamResponse AddSpammer(string username, string email, string ip, string evidence = null);
		StopForumSpamResponse AddSpammer(string username, string email, string ip, string apikey, string evidence = null);
		StopForumSpamResponse AddSpammer(AddSpammerParameters parameters);
	}
}
