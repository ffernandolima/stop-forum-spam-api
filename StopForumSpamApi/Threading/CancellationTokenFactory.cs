using System.Threading;

namespace StopForumSpamApi.Threading
{
	public static class CancellationTokenFactory
	{
		public static CancellationToken Token()
		{
			var cancellationTokenSource = new CancellationTokenSource();

			var cancellationToken = cancellationTokenSource.Token;

			return cancellationToken;
		}
	}
}
