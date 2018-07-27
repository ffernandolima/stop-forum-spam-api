using StopForumSpamApi.Parameters;
using StopForumSpamApi.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StopForumSpamApi.Clients
{
	/// <remarks>
	/// https://www.stopforumspam.com/usage
	/// </remarks>
	public interface IStopForumSpamApiClient : IDisposable
	{
		TimeSpan Timeout { get; set; }

		StopForumSpamResponse CheckIp(string ip);
		Task<StopForumSpamResponse> CheckIpAsync(string ip);
		Task<StopForumSpamResponse> CheckIpAsync(string ip, CancellationToken cancellationToken);

		StopForumSpamResponse CheckEmail(string email);
		Task<StopForumSpamResponse> CheckEmailAsync(string email);
		Task<StopForumSpamResponse> CheckEmailAsync(string email, CancellationToken cancellationToken);

		StopForumSpamResponse CheckUsername(string username);
		Task<StopForumSpamResponse> CheckUsernameAsync(string username);
		Task<StopForumSpamResponse> CheckUsernameAsync(string username, CancellationToken cancellationToken);

		StopForumSpamResponse Check(string username, string email, string ip);
		Task<StopForumSpamResponse> CheckAsync(string username, string email, string ip);
		Task<StopForumSpamResponse> CheckAsync(string username, string email, string ip, CancellationToken cancellationToken);

		StopForumSpamResponse Check(CheckParameters parameters);
		Task<StopForumSpamResponse> CheckAsync(CheckParameters parameters);
		Task<StopForumSpamResponse> CheckAsync(CheckParameters parameters, CancellationToken cancellationToken);

		StopForumSpamResponse AddSpammer(string username, string email, string ip, string evidence = null);
		Task<StopForumSpamResponse> AddSpammerAsync(string username, string email, string ip, string evidence = null);
		Task<StopForumSpamResponse> AddSpammerAsync(string username, string email, string ip, CancellationToken cancellationToken, string evidence = null);

		StopForumSpamResponse AddSpammer(string username, string email, string ip, string apikey, string evidence = null);
		Task<StopForumSpamResponse> AddSpammerAsync(string username, string email, string ip, string apikey, string evidence = null);
		Task<StopForumSpamResponse> AddSpammerAsync(string username, string email, string ip, string apikey, CancellationToken cancellationToken, string evidence = null);

		StopForumSpamResponse AddSpammer(AddSpammerParameters parameters);
		Task<StopForumSpamResponse> AddSpammerAsync(AddSpammerParameters parameters);
		Task<StopForumSpamResponse> AddSpammerAsync(AddSpammerParameters parameters, CancellationToken cancellationToken);
	}
}
