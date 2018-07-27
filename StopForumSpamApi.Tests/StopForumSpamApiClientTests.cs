using Microsoft.VisualStudio.TestTools.UnitTesting;
using StopForumSpamApi.Clients;
using StopForumSpamApi.Parameters;

namespace StopForumSpamApi.Tests
{
	[TestClass]
	public class StopForumSpamApiClientTests
	{
		[TestMethod]
		public void CheckTestMethod()
		{
			IStopForumSpamApiClient client = null;

			try
			{
				client = new StopForumSpamApiClient();

				var response = client.CheckIp("5.188.210.7");
				Assert.AreEqual(true, response.Successful);

				response = client.CheckEmail("asd@asd.com");
				Assert.AreEqual(true, response.Successful);

				response = client.CheckUsername("Targeted website visitors");
				Assert.AreEqual(true, response.Successful);

				response = client.Check("Targeted website visitors", "asd@asd.com", "5.188.210.7");
				Assert.AreEqual(true, response.Successful);

				response = client.Check(new CheckParameters { Username = "Targeted website visitors", Email = "asd@asd.com", Ip = "5.188.210.7" });
				Assert.AreEqual(true, response.Successful);
			}
			finally
			{
				if (client != null)
				{
					client.Dispose();
				}
			}
		}
	}
}
